﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskWaveAccess.Models
{
	public class User
	{
		public User()
		{
			Roles = new HashSet<Role>();
			Ratings = new HashSet<Rating>();
		}
		[ScaffoldColumn(false)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		[Required]
		[Display(Name = "User name")]
		public string UserName { get; set; }
		[Display(Name = "Date of birth")]
		[Range(typeof(DateTime), "1/1/1900", "1/1/2020", ErrorMessage = "Date is out of Range")]
		public DateTime BirthDate { get; set; }
		[Required]
		[Display(Name = "Registration date")]
		[DefaultValue("1/1/1900")]
		public DateTime RegistrationDate { get; set; }
		[Required]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[Compare("Password", ErrorMessage = "Incorrect Email or Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Biography")]
		public string Bio { get; set; }
		[Required]
		[Display(Name = "User is blocked")]
		public bool IsBlocked { get; set; }

		public virtual ICollection<Role> Roles { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }
	}
}