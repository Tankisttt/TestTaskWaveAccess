using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

		public IActionResult Index()
		{
			return View(_db.Movies.ToList());
		}
	}
}
