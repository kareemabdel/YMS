using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class CurrencyDTO : BaseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Remarks { get; set; }
        public double? ExchangeRate { get; set; }
    }
}
