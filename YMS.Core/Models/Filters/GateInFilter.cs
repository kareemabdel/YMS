using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Filters
{
    public class GateInFilter : Filter
    {
        public DateTime? GateInDateFrom { get; set; }
        public DateTime? GateInDateTo { get; set; }
    }
}
