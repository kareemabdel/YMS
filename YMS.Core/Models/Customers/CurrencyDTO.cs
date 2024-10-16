using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class CurrencyDTO
    {
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string? NameAr { get; set; }
    }
}
