using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;
using X.PagedList;

namespace TestTaskWaveAccess.Controllers
{
	public class ActorController : Controller
	{
		readonly ApplicationContext _db;

		public ActorController(ApplicationContext context)
		{
			_db = context;
		}
        public async Task<IActionResult> Details(int? actorId)
        {
            if (actorId == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            var actor = await _db.Actors
                                .Include(x => x.Movies)
                                .FirstOrDefaultAsync(m => m.ActorId == actorId);

            if (actor == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            return View(actor);
        }

        public ActionResult Index(SortStateActor sortOrder = SortStateActor.FullNameAsc, int page = 1)
        {
            const int pageSize = 10;
            ViewBag.CurrentSort = sortOrder;

            ViewData["BirthDateSort"] = sortOrder == SortStateActor.BirthDateAsc ? SortStateActor.BirthDateDesc : SortStateActor.BirthDateAsc;
            ViewData["FullNameSort"] = sortOrder == SortStateActor.FullNameAsc ? SortStateActor.FullNameDesc : SortStateActor.FullNameAsc;

            IQueryable<Actor> source = ViewBag.CurrentSort switch
            {
                SortStateActor.BirthDateAsc => _db.Actors.OrderBy(s => s.BirthDate),
                SortStateActor.BirthDateDesc => _db.Actors.OrderByDescending(s => s.BirthDate),
                SortStateActor.FullNameAsc => _db.Actors.OrderBy(s => s.FullName),
                SortStateActor.FullNameDesc => _db.Actors.OrderByDescending(s => s.FullName),
                _ => _db.Actors.OrderBy(s => s.FullName),
            };

            return View(source.ToPagedList(page, pageSize));
        }
    }
}
