using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Filters
{
    public class SortByModel
    {
        //-1 desc, 1 asc
        public int SortOrder { get; set; } = -1;
        public string? SortField { get; set; }
    }
}
