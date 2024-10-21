using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models
{
    public class Filter 
    {
        public Guid? BranchId { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? SearchKey { get; set; }
        public bool IsDescending { get; set; }
        public string? SortField { get; set; }
    }
}
