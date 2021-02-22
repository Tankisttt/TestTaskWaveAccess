using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class Genre
	{
		public Genre()
		{
			Movies = new HashSet<Movie>();
		}

		public int GenreId { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}