using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskWaveAccess.Models
{
	public class Role
	{
		public Role()
		{
			Users = new HashSet<User>();
		}
		[ScaffoldColumn(false)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RoleId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}