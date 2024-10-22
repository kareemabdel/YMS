using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Entities
{
    public class ContainerTransaction:BaseEntity
    {
        public Guid Id { get; set; }   
        public Guid ContainerId { get; set; }
        public int TransporterId { get; set; }  
        public string? DriverMobileNumber { get; set; }
        public string? DeliveryCardNo { get; set; }
        public string? DriverID { get; set; }
        public decimal? CleanCost { get; set; }
        public decimal? RepairCost { get; set; }
        public int GateInBlockId { get; set; }
        [Range(10, 99, ErrorMessage = "The Bay value must be a two-digit integer.")]
        public short GateInBay { get; set; }

        [Range(10, 99, ErrorMessage = "The Rows value must be a two-digit integer.")]
        public short GateInRows { get; set; }

        [Range(0, 9, ErrorMessage = "The Tier value must be a one-digit integer.")]
        public short GateInTier { get; set; }

        public int? ActualBlockId { get; set; }
        [Range(10, 99, ErrorMessage = "The Bay value must be a two-digit integer.")]
        public short? ActualBay { get; set; }

        [Range(10, 99, ErrorMessage = "The Rows value must be a two-digit integer.")]
        public short? ActualRows { get; set; }

        [Range(0, 9, ErrorMessage = "The Tier value must be a one-digit integer.")]
        public short? ActualTier { get; set; }
        public int AllocationStatus { get; set; } // AllocationStatusEnum pending - confirmed 

        /// <summary>
        /// ref
        /// </summary>
        public Transporter Transporter { get; set; }
        public Block Block { get; set; }
        public Container Container { get; set; }
    }
}
