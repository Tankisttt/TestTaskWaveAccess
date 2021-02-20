using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class UserController : Controller
	{
		public UserController()
		{
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
