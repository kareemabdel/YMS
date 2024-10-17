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
        public string ContainerNo { get; set; }
        public int ContainerTypeId { get; set; }
        public bool IsRORO { get; set; }
        public Guid CustomerId { get; set; }
        public int TransporterId { get; set; }
        public DateTime GateInDate { get; set; }
        public string TruckNo { get; set; }
        public string DriverMobile { get; set; }
        public string DeliveryCardNo { get; set; }
        public int VesselId { get; set; }
        public string Voyage { get; set; }
        public DateTime ETA { get; set; }
        public int EIR { get; set; } //EIREnum
        public int ContainerShippingStatus { get; set; } //ContainerShippingStatusEnum
        public string InspectionRemarks { get; set; }
        public string BillNo { get; set; }
        public decimal CleanCost { get; set; }
        public decimal RepairCost { get; set; }
        public int BlockId { get; set; }
        [Range(10, 99, ErrorMessage = "The Bay value must be a two-digit integer.")]
        public short Bay { get; set; }

        [Range(10, 99, ErrorMessage = "The Rows value must be a two-digit integer.")]
        public short Rows { get; set; }

        [Range(0, 9, ErrorMessage = "The Tier value must be a one-digit integer.")]
        public short Tier { get; set; }
        public int Status { get; set; } //ContainerStatusEnum

        /// <summary>
        /// ref
        /// </summary>
        public ContainerType ContainerType { get; set; }
        public Customer Customer { get; set; }
        public Transporter Transporter { get; set; }
        public Vessel Vessel { get; set; }
        public Block Block { get; set; }
        public ICollection<InspectionDetail> InspectionDetails { get; set; } = new List<InspectionDetail>();
    }
}
