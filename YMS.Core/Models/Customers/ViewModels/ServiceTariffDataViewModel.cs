using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class ServiceTariffDataViewModel  : ExtraTariffServiceDataViewModel
    {
        public decimal? Amount20 { get; set; }
        public decimal? Amount40 { get; set; }
        public bool Full { get; set; }
        public bool Empty { get; set; }
    }
}
