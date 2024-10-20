using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Filters
{
    public class CustomerFilter:SortByModel
    {
        public Guid? BranchId { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? SearchKey { get; set; }

    }
}
