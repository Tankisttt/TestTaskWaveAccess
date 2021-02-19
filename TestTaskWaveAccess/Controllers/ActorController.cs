using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class ActorController : Controller
	{
		List<Actor> actors;

		public ActorController()
		{
			actors = new List<Actor>
			{
				new Actor { Id = 1, Bio = "Was born, was died", BirthYear = 1889, FullName = "Charles Spencer Chaplin" },
				new Actor { Id = 2, Bio = "Was born", BirthYear = 1969, FullName = "Matthew David McConaughey" },
				new Actor { Id = 3, Bio = "Was born", BirthYear = 1971, FullName = "Jared Joseph Leto" },
				new Actor { Id = 4, Bio = "Was born", BirthYear = 1976, FullName = "Samuel Henry J. Worthington" },
			};
		}

		public IActionResult Index()
		{
			return View(actors);
		}
	}
}
