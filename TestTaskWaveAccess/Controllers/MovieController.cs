﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Net;
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
        public ActionResult Details(int? movieId)
        {
            if (movieId == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            
            var movie = _db.Movies.Find(movieId);
            
            if (movie == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound); 

            return View(movie);
        }


        public async Task<IActionResult> Index(SortState sortOrder = SortState.TitleAsc, int page = 1)
        {
            const int pageSize = 10;
            ViewBag.CurrentSort = sortOrder;
            
            ViewData["ReleaseYearSort"]     = sortOrder == SortState.ReleaseYearAsc ? SortState.ReleaseYearDesc : SortState.ReleaseYearAsc;
            ViewData["TitleSort"]           = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["AverageRatingSort"]   = sortOrder == SortState.AverageRatingAsc ? SortState.AverageRatingDesc : SortState.AverageRatingAsc;
            ViewData["NumVotesSort"]        = sortOrder == SortState.NumVotesAsc ? SortState.NumVotesDesc : SortState.NumVotesAsc;

            IQueryable<Movie> source = ViewBag.CurrentSort switch
            {
                SortState.ReleaseYearAsc    => _db.Movies.OrderBy(s => s.ReleaseYear),
                SortState.ReleaseYearDesc   => _db.Movies.OrderByDescending(s => s.ReleaseYear),
                SortState.TitleAsc          => _db.Movies.OrderBy(s => s.Title),
                SortState.TitleDesc         => _db.Movies.OrderByDescending(s => s.Title),
                SortState.AverageRatingAsc  => _db.Movies.OrderBy(s => s.AverageRating),
                SortState.AverageRatingDesc => _db.Movies.OrderByDescending(s => s.AverageRating),
                SortState.NumVotesAsc       => _db.Movies.OrderBy(s => s.NumVotes),
                SortState.NumVotesDesc      => _db.Movies.OrderByDescending(s => s.NumVotes),
                _ => _db.Movies.OrderBy(s => s.Title),
            };
            
            return View(await source.ToPagedListAsync<Movie>(page, pageSize));
        }
    }
}
