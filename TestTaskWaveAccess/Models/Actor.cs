using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class Actor
	{
		public Actor()
		{
			Movies = new HashSet<Movie>();		
		}

		public int ActorId { get; set; }
		public DateTime BirthDate { get; set; }
		[Required]
		public string FullName { get; set; }
		public string Bio { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}