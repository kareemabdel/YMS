using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class PackageServiceTariffData : ExtraTariffServiceData
    {
        [Required]
        public Guid PackageServicesTariffId { get; set; }
        public PackageServicesTariff PackageServicesTariff { get; set; }

        public int PackageTypeId { get; set; }
        public PackageType PackageType { get; set; }
    }
}
