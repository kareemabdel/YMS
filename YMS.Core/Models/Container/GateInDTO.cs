using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Container
{
    public class GateInDTO
    {
        public Guid Id { get; set; }
        public string ContainerNo { get; set; }
        public string Customer { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string? Line { get; set; }
        public string CreatedDate { get; set; }
        public string? EIRRemark { get; set; }
        public string AllocationStatus { get; set; }
    }
}
