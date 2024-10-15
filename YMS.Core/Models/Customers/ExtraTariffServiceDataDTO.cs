using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class ExtraTariffServiceDataDTO
    {
        public Guid? Id { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public ServiceDTO Services { get; set; }

        [Required]
        public int BasisId { get; set; }
        public BasisDTO Basis { get; set; }
        public string? Remarks { get; set; }
        public decimal? Amount { get; set; }

    }
}
