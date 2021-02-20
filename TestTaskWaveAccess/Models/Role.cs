using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskWaveAccess.Models
{
	public class Role
	{
		public Role()
		{
			Users = new HashSet<User>();
		}

		public int RoleId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}