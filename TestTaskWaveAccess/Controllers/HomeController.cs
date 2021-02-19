using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class HomeController : Controller
	{
		List<User> users;

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			users = new List<User>
			{
				new User {Id = 1, Age = 20, Bio = "Hiii", IsBlocked = false, Name = "Roman", RegistrationDate = DateTime.Now },
				new User {Id = 2, Age = 30, Bio = "I'm coder", IsBlocked = false, Name = "John", RegistrationDate = DateTime.Now },
				new User {Id = 3, Age = 40, Bio = "I'm engineer", IsBlocked = false, Name = "Ivan", RegistrationDate = DateTime.Now },
				new User {Id = 4, Age = 50, Bio = "I'm cook", IsBlocked = false, Name = "Anton", RegistrationDate = DateTime.Now },
				new User {Id = 5, Age = 60, Bio = "I'm cat", IsBlocked = false, Name = "Alex", RegistrationDate = DateTime.Now },
				new User {Id = 6, Age = 70, Bio = "I'm oldman", IsBlocked = false, Name = "Sasha", RegistrationDate = DateTime.Now },
			};



			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(users);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
