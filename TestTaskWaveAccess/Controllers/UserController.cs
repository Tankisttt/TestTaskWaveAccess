using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestTaskWaveAccess.Models;

namespace TestTaskWaveAccess.Controllers
{
	public class UserController : Controller
	{
		List<User> users;

		public UserController()
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
		}

		public IActionResult Index()
		{
			return View(users);
		}
	}
}
