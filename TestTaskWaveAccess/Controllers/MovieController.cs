using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class MovieController : Controller
	{
		public MovieController()
		{
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
