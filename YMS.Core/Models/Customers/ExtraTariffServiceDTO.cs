using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class ExtraTariffServiceDTO
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string? Remarks { get; set; }
    }
}
