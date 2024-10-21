using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities.Lookups
{
    public class City : LookupBase
    {
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
