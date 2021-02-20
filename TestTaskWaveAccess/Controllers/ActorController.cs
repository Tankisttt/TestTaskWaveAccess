using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class ActorController : Controller
	{
		public ActorController()
		{

		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
