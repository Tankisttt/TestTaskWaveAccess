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
		List<Movie> movies;
		public MovieController()
		{
			movies = new List<Movie>
			{
				new Movie {Id = 1, ReleaseYear = 2009, Title = "Avatar", Description = "Blue mans", Rating = 0.0f },
				new Movie {Id = 4, ReleaseYear = 2014, Title = "Interstellar", Description = "Ooo science Black Holes", Rating = 0.0f },
				new Movie {Id = 5, ReleaseYear = 2013, Title = "Dallas Buyers Club", Description = "True story about AIDS", Rating = 0.0f },
				new Movie {Id = 6, ReleaseYear = 2018, Title = "Green Book", Description = "Road movie", Rating = 0.0f },
				new Movie {Id = 7, ReleaseYear = 2019, Title = "1917", Description = "Great movie about Great War", Rating = 0.0f },
			};
		}

		public IActionResult Index()
		{
			return View(movies);
		}
		//[NonAction]
	}
}
