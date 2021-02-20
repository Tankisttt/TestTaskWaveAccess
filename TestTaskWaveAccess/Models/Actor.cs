using System.Collections.Generic;

namespace TestTaskWaveAccess.Models
{
	public class Actor
	{
		public Actor()
		{
			Movies = new HashSet<Movie>();		
		}

		public int ActorId { get; set; }
		public int BirthYear { get; set; }
		public string FullName { get; set; }
		public string Bio { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}