using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class ServiceTariffDataDTO : ExtraTariffServiceDataDTO
    {
        public decimal? Amount20 { get; set; }
        public decimal? Amount40 { get; set; }
        public bool Full { get; set; }
        public bool Empty { get; set; }
    }
}

