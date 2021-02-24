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
		[Display(Name = "Birth date")]
		public DateTime BirthDate { get; set; }
		[Required]
		[Display(Name = "Full name")]
		public string FullName { get; set; }
		[Display(Name = "Biography")]
		public string Bio { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}