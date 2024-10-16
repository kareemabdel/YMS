using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class GetCustomerRequestModel
    {
        [Required]
        public Guid CustomerId { get; set; }
        public Guid? BranchId { get; set; }
    }
}
