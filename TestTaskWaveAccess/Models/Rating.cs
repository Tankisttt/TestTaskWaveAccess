using System.ComponentModel.DataAnnotations;

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
		[Range(0, 10, ErrorMessage = "Only positive number allowed")]
		public float Value { get; set; }
	}
}
