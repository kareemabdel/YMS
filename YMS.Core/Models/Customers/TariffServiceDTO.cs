using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers
{
    public class TariffServiceDTO
    {
        public Guid Id { get; set; }

        public ServiceDTO Service { get; set; }
        public BasisDTO Basis { get; set; }

        public decimal? Amount20 { get; set; }
        public decimal? Amount40 { get; set; }
        public decimal? Amount { get; set; }
        public string? Remarks { get; set; }
    }
}
