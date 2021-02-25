using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[ScaffoldColumn(false)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MovieId { get; set; }
		[Display(Name = "Movie release year")]
		[Range(1700, 2100)]
		public int ReleaseYear { get; set; }
		[Required]
		[Display(Name = "Movie title")]
		public string Title { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Movie average rating")]
		[Range(0, 10)]
		public float AverageRating { get; set; }
		[Display(Name = "Num of votes")]
		[Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
		public int NumVotes { get; set; }

		public virtual ICollection<Actor> Actors { get; set; }
		public virtual ICollection<Genre> Genres { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }

	}
}