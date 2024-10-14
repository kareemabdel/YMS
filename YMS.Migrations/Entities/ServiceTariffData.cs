using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class ServiceTariffData : ExtraTariffServiceData
    {
        [Required]
        public Guid ServicesTariffId { get; set; }
        public ServicesTariff ServicesTariff { get; set; }
        public decimal Amount20 { get; set; }
        public decimal Amount40 { get; set; }
        public bool Full { get; set; }
        public bool Empty { get; set; }
    }
}

