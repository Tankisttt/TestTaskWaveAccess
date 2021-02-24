using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
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
        public ActionResult Delete(int MovieId)
        {
            var data = _db.Movies.FirstOrDefault(x => x.MovieId == MovieId);
            if (data != null)
            {
                _db.Movies.Remove(data);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public async Task<IActionResult> Details(int? movieId)
        {
            if (movieId == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            
            var movie = await _db.Movies
                                .Include(x => x.Genres)
                                .FirstOrDefaultAsync(m => m.MovieId == movieId);
            
            if (movie == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound); 

            return View(movie);
        }


        public ActionResult Index(SortStateMovie sortOrder = SortStateMovie.TitleAsc, int page = 1)
        {
            const int pageSize = 10;
            ViewBag.CurrentSort = sortOrder;
            
            ViewData["ReleaseYearSort"]   = sortOrder == SortStateMovie.ReleaseYearAsc ? SortStateMovie.ReleaseYearDesc : SortStateMovie.ReleaseYearAsc;
            ViewData["TitleSort"]         = sortOrder == SortStateMovie.TitleAsc ? SortStateMovie.TitleDesc : SortStateMovie.TitleAsc;
            ViewData["AverageRatingSort"] = sortOrder == SortStateMovie.AverageRatingAsc ? SortStateMovie.AverageRatingDesc : SortStateMovie.AverageRatingAsc;
            ViewData["NumVotesSort"]      = sortOrder == SortStateMovie.NumVotesAsc ? SortStateMovie.NumVotesDesc : SortStateMovie.NumVotesAsc;

            IQueryable<Movie> source = ViewBag.CurrentSort switch
            {
                SortStateMovie.ReleaseYearAsc    => _db.Movies.OrderBy(s => s.ReleaseYear),
                SortStateMovie.ReleaseYearDesc   => _db.Movies.OrderByDescending(s => s.ReleaseYear),
                SortStateMovie.TitleAsc          => _db.Movies.OrderBy(s => s.Title),
                SortStateMovie.TitleDesc         => _db.Movies.OrderByDescending(s => s.Title),
                SortStateMovie.AverageRatingAsc  => _db.Movies.OrderBy(s => s.AverageRating),
                SortStateMovie.AverageRatingDesc => _db.Movies.OrderByDescending(s => s.AverageRating),
                SortStateMovie.NumVotesAsc       => _db.Movies.OrderBy(s => s.NumVotes),
                SortStateMovie.NumVotesDesc      => _db.Movies.OrderByDescending(s => s.NumVotes),
                _ => _db.Movies.OrderBy(s => s.Title),
            };
            
            return View(source.ToPagedList(page, pageSize));
        }
    }
}
