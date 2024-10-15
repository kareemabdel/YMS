using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class ExtraTariffServiceDataViewModel
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int BasisId { get; set; }
        public string? Remarks { get; set; }
        public decimal? Amount { get; set; }
    }
}
