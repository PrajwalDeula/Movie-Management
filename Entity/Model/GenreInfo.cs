using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entity.Common;

namespace Entity.Model
{
    public class GenreInfo : BaseModel
    {
        [Key]
        public int GenreInfoID { get; set; }
        public string GenreName { get; set; }
        public string GenreCode { get; set; }

        
    }

 }

