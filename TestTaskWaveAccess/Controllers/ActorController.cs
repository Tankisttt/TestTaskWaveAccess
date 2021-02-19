using Microsoft.AspNetCore.Mvc;

namespace TestTaskWaveAccess.Controllers
{
	public class ActorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
