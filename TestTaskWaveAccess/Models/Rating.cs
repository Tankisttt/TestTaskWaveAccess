using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskWaveAccess.Models
{
	public class Rating
	{
		[Key]
		public int UserId { get; set; }
		[Key]
		public int MovieId { get; set; }

		public virtual User User { get; set; }
		public virtual Movie Movie { get; set; }

		public float Value { get; set; }
	}
}
