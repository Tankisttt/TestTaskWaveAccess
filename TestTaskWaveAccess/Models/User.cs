using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class User
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public bool IsBlocked { get; set; }
		[Required]
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Email { get; set; }
		public string Bio { get; set; }
	}
}
