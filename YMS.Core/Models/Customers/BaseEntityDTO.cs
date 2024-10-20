using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class BaseEntityDTO
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTime.Now;
        public DateTimeOffset? UpdatedDate { get; set; }
        public Guid? CreatedById { get; set; }
    }
}
