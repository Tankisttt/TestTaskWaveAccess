using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class MovieController : Controller
	{
		readonly ApplicationContext _db;
		public MovieController(ApplicationContext context)
		{
			_db = context;
		}
		}
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;

            IQueryable<Movie> source = _db.Movies;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Movies = items
            };
            return View(viewModel);
        }
    }
}
