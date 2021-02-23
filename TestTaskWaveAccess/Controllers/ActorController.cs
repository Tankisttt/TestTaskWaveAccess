using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class ActorController : Controller
	{
		readonly ApplicationContext _db;

		public ActorController(ApplicationContext context)
		{
			_db = context;
		}

        public async Task<IActionResult> Index(int page = 1)
        {

            IQueryable<Actor> source = _db.Actors;
            return View(source);
        }
    }
}
