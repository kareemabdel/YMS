using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;
using YMS.Migrations.Migrations;

namespace YMS.Migrations.Entities
{
    public class Container:BaseEntity
    {
        public Guid Id { get; set; }
        public string ContainerNo { get; set; }
        public string? Ref { get; set; }
        public int? VesselId { get; set; }
        public Guid? CustomerId { get; set; }
        public int ContainerTypeId { get; set; }
        public int? ShippingStatus { get; set; } //ContainerShippingStatusEnum
        public string? LoadPosition { get; set; }
        public string? BayCell { get; set; }
        public string? TempRqd { get; set; }
        public string? IMOClass { get; set; }
        public string? OOG { get; set; }
        public string? DMG { get; set; }
        public string? BillNumber { get; set; }
        public string? Remarks { get; set; }
        public string? Weight { get; set; }
        public string? ISO { get; set; }
        public string? Voyage { get; set; }
        public DateTime? ETA { get; set; }
        public int Status { get; set; } //ContainerStatusEnum
        public bool? IsRORO { get; set; }
        public string TruckNo { get; set; }
        public string SealNumber { get; set; }
        public string ContainerCondition { get; set; }
        public int EIR { get; set; } // EIREnum
        public string? EIRRemarks { get; set; }
        /// <summary>
        /// ref
        /// </summary>
        public Customer Customer { get; set; }
        public Vessel Vessel { get; set; }
        public ContainerType ContainerType { get; set; }

        public ICollection<InspectionDetail> InspectionDetails { get; set; }
        public ICollection<ContainerTransaction> ContainerTransactions { get; set; }

    }
}
