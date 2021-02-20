using System.Collections.Generic;

namespace TestTaskWaveAccess.Models
{
	public class Genre
	{
		public Genre()
		{
			Movies = new HashSet<Movie>();
		}

		public int GenreId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}