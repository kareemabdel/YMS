using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class CustomerListDTO
    {
        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string? TaxNumber { get; set; }
        public string HasVat { get; set; }
        public string Phone1 { get; set; }
        public string? Email { get; set; }
        public int PaymentType { get; set; }
        public string? ContactPerson { get; set; }
    }
}
