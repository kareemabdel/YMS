using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class PackageServicesTariffDTO : ExtraTariffServiceDTO
    {
        public int StorageFreeDays { get; set; }

        public List<PackageServiceTariffDataDTO> PackageServiceTariffDataList { get; set; }
    }
}
