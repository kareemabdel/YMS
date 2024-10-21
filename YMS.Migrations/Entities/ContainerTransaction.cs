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
        public bool IsRORO { get; set; }
        public Guid ContainerId { get; set; }
        public Guid CustomerId { get; set; }
        public int? LineId { get; set; }
        public int TransporterId { get; set; }
        public string TruckNo { get; set; }
        public string? DriverMobileNumber { get; set; }
        public string? DeliveryCardNo { get; set; }
        public string? DriverID { get; set; }
        public decimal? CleanCost { get; set; }
        public decimal? RepairCost { get; set; }
        public int? BlockId { get; set; }
        [Range(10, 99, ErrorMessage = "The Bay value must be a two-digit integer.")]
        public short? Bay { get; set; }

        [Range(10, 99, ErrorMessage = "The Rows value must be a two-digit integer.")]
        public short? Rows { get; set; }

        [Range(0, 9, ErrorMessage = "The Tier value must be a one-digit integer.")]
        public short? Tier { get; set; }
        public int Status { get; set; } //ContainerStatusEnum

        /// <summary>
        /// ref
        /// </summary>
        public ContainerType ContainerType { get; set; }
        public Customer Customer { get; set; }
        public Transporter Transporter { get; set; }
        public Block Block { get; set; }
        public Line Line { get; set; }
        public Container Container { get; set; }
    }
}
