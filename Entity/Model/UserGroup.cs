using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
	public class UserGroup:BaseModel
	{

	[Key]
		public int UserGroupID { get; set; }
		public string UserGroupName { get; set; }
		public string UserGroupCode { get; set; }
		
		public bool IsActive { get; set; }
    }
	
}