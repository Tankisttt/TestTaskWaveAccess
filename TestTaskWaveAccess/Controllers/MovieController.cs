using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(SortState sortOrder = SortState.TitleAsc, int page = 1)
        {
            const int pageSize = 10;
            ViewData["ReleaseYearSort"]     = sortOrder == SortState.ReleaseYearAsc ? SortState.ReleaseYearDesc : SortState.ReleaseYearAsc;
            ViewData["TitleSort"]           = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            ViewData["AverageRatingSort"]   = sortOrder == SortState.AverageRatingAsc ? SortState.AverageRatingDesc : SortState.AverageRatingAsc;
            ViewData["NumVotesSort"]        = sortOrder == SortState.NumVotesAsc ? SortState.NumVotesDesc : SortState.NumVotesAsc;
            
            IQueryable<Movie> source = sortOrder switch
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
            
            return View(source.ToPagedList<Movie>(page, pageSize));
        }
    }
}
