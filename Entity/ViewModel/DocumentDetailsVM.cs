using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
	public class DocumentDetailsVM
	{ 
		
		public int id { get; set; }
		public int DocTypeId { get; set; }
		public bool IsChange { get; set; }
		public bool IsDeleted { get; set; }
		public string DocTypeName { get; set; }
		public string DocGuid { get; set; }
		public string FileExtension { get; set; }
		public string Filename { get; set; }
		public string DocNo { get; set; }
		public string DocTitle { get; set; }
		public string mimeType { get; set; }
		public string BaseLocation { get; set; }
		

	}
}
