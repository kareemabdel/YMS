using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class InspectionDetail:BaseEntity
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public int Code { get; set; }
        public int Name { get; set; }
        public Guid ContainerTransactionId { get; set; }
        public ContainerTransaction ContainerTransaction { get; set; }
    }
}
