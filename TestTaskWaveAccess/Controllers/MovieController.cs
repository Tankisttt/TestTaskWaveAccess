using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;
using X.PagedList;

namespace TestTaskWaveAccess.Controllers
{
	public class MovieController : Controller
	{
		readonly ApplicationContext _db;
		public MovieController(ApplicationContext context)
		{
			_db = context;
		}
        #region CRUD
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                ModelState.Remove("MovieId");
                if (ModelState.IsValid)
                {
                    _db.Movies.Add(movie);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dataException)
            {
                ModelState.AddModelError(dataException.Message, "Unable to save changes. Try again or Contact to the Administrator");
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? MovieId)
        {
            if (MovieId == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);

            var movie = _db.Movies.FirstOrDefault(x => x.MovieId == MovieId);
            if (movie != null)
            {
                _db.Entry(movie).State = EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public ActionResult Edit(int? MovieId)
        {
            if (MovieId == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            
            var movieToEdit = _db.Movies.Find(MovieId);
            if (movieToEdit == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            return View(movieToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        #endregion
        public async Task<IActionResult> Details(int? movieId)
        {
            if (movieId == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            
            var movie = await _db.Movies
                                .Include(x => x.Genres)
                                .FirstOrDefaultAsync(m => m.MovieId == movieId);
            
            if (movie == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound); 

            return View(movie);
        }
        //Fat controller!!!
        public ActionResult Index( string movieGenre,
                                   string searchStringActor,
                                   SortStateMovie sortOrder = SortStateMovie.TitleAsc,
                                   int page = 1)
        {
            IQueryable<Movie> movies = _db.Movies;
            const int pageSize = 10;
            ViewBag.CurrentSort = sortOrder;
            
            ViewData["ReleaseYearSort"]   = sortOrder == SortStateMovie.ReleaseYearAsc ? SortStateMovie.ReleaseYearDesc : SortStateMovie.ReleaseYearAsc;
            ViewData["TitleSort"]         = sortOrder == SortStateMovie.TitleAsc ? SortStateMovie.TitleDesc : SortStateMovie.TitleAsc;
            ViewData["AverageRatingSort"] = sortOrder == SortStateMovie.AverageRatingAsc ? SortStateMovie.AverageRatingDesc : SortStateMovie.AverageRatingAsc;
            ViewData["NumVotesSort"]      = sortOrder == SortStateMovie.NumVotesAsc ? SortStateMovie.NumVotesDesc : SortStateMovie.NumVotesAsc;
            ViewData["CurrentActorFilter"] = searchStringActor;
            ViewData["CurrentGenreFilter"] = searchStringActor;

            if (!String.IsNullOrEmpty(searchStringActor))
                movies = movies.Where(m => m.Actors.Any(a => a.FullName.Contains(searchStringActor)));

            if (!String.IsNullOrEmpty(movieGenre))
                movies = movies.Where(m => m.Genres.Any(a => a.Title.Contains(movieGenre)));

            movies = ViewBag.CurrentSort switch
            {
                SortStateMovie.ReleaseYearAsc    => movies.OrderBy(s => s.ReleaseYear),
                SortStateMovie.ReleaseYearDesc   => movies.OrderByDescending(s => s.ReleaseYear),
                SortStateMovie.TitleAsc          => movies.OrderBy(s => s.Title),
                SortStateMovie.TitleDesc         => movies.OrderByDescending(s => s.Title),
                SortStateMovie.AverageRatingAsc  => movies.OrderBy(s => s.AverageRating),
                SortStateMovie.AverageRatingDesc => movies.OrderByDescending(s => s.AverageRating),
                SortStateMovie.NumVotesAsc       => movies.OrderBy(s => s.NumVotes),
                SortStateMovie.NumVotesDesc      => movies.OrderByDescending(s => s.NumVotes),
                _ => _db.Movies.OrderBy(s => s.Title),
            };

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(_db.Genres.Distinct().Select(x => x.Title).ToList()),
                Movies = movies.ToPagedList(page, pageSize)
            };
            return View(movieGenreVM);
        }
    }
}
