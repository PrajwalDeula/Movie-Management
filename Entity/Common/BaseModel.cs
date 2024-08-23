using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Model;

namespace Entity.Common
{
    public class BaseModel
    {

        public int Status { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        
        public int? ModifiedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Users { get; set; }
    }
}
