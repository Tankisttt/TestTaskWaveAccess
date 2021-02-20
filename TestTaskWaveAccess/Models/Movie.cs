using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class Movie
	{
		public Movie()
		{
			Actors = new HashSet<Actor>();
			Genres = new HashSet<Genre>();
			Ratings = new HashSet<Rating>();
		}

		public int MovieId { get; set; }
		public int ReleaseYear { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		public float AverageRating { get; set; }
		public int NumVotes { get; set; }

		public virtual ICollection<Actor> Actors { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }

	}
}