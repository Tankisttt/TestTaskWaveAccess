﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskWaveAccess.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public int ReleaseYear { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public float Rating { get; set; }
	}
}