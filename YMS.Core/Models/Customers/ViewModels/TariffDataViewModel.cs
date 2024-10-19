using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class TariffDataViewModel
    {
        [Required]
        public int DaysNum { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public int? StorageTypeId { get; set; }
    }
}
