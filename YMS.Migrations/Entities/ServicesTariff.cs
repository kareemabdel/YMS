using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class ServicesTariff : ExtraTariffService
    {
        public List<ServiceTariffData> ServiceTariffDataList { get; set; }
    }
}
