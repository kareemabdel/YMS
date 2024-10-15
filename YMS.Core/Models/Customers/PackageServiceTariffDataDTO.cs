using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class PackageServiceTariffDataDTO : ExtraTariffServiceDataDTO
    {
        [Required]
        public Guid PackageServicesTariffId { get; set; }
        public PackageServicesTariffDTO PackageServicesTariff { get; set; }

        public int PackageTypeId { get; set; }
        public PackageTypeDTO PackageType { get; set; }
    }
}
