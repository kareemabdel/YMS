using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class StorageTariffDataDTO
    {
        public Guid Id { get; set; }

        [Required]
        public int DaysNum { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
