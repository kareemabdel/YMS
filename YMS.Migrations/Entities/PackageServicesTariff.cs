using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class PackageServicesTariff : ExtraTariffService
    {
        public int StorageFreeDays { get; set; }

        public List<PackageServiceTariffData> PackageServiceTariffDataList { get; set; }
    }
}
