using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class ServicesTariffDTO : ExtraTariffServiceDTO
    {
        public List<ServiceTariffDataDTO> ServiceTariffDataList { get; set; }
    }
}
