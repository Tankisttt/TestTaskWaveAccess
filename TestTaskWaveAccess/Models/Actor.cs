using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskWaveAccess.Models
{
	public class Actor
	{
		public Actor()
		{
			Movies = new HashSet<Movie>();		
		}
		[ScaffoldColumn(false)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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