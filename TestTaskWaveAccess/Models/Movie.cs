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
		[Display(Name = "Movie release year")]
		public int ReleaseYear { get; set; }
		[Required]
		[Display(Name = "Movie title")]
		public string Title { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Movie average rating")]
		public float AverageRating { get; set; }
		[Display(Name = "Num of votes")]
		public int NumVotes { get; set; }

		public virtual ICollection<Actor> Actors { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }

	}
}