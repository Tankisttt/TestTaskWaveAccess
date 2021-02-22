﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class User
	{
		public User()
		{
			Roles = new HashSet<Role>();
			Ratings = new HashSet<Rating>();
		}

		public int UserId { get; set; }
		[Required]
		public string UserName { get; set; }
		public DateTime BirthDate { get; set; }
		[Required]
		public DateTime RegistrationDate { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public string Bio { get; set; }
		[Required]
		public bool IsBlocked { get; set; }

		public virtual ICollection<Role> Roles { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }
	}
}