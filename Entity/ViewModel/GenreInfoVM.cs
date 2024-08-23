using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
	public class GenreInfoVM : BaseModel
	{
		public int GenreInfoID { get; set; }
		public string GenreCode { get; set; }
		public string GenreName { get; set; }
		
	}
}
