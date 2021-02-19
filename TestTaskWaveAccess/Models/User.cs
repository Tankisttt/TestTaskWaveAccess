using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
		/// <summary>
		/// IMDB contains that field
		/// </summary>
		public string Bio { get; set; }
	}
}
