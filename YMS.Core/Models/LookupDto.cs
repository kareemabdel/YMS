using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models
{
    public class LookupDto
    {
        public int Id { get; set; }

        [Required]
        public string NameEn { get; set; }
    }
}
