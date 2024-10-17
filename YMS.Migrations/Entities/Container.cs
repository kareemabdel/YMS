using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Entities
{
    public class Container:BaseEntity
    {
        public Guid Id { get; set; }
        public string ContainerNo { get; set; }
        public string Ref { get; set; }
        public int VesselId { get; set; }
        public Guid CustomerId { get; set; }
        public int ContainerTypeId { get; set; }
        public int ShippingStatus { get; set; } //ContainerShippingStatusEnum
        public string LoadPosition { get; set; }
        public string BayCell { get; set; }
        public string TempRqd { get; set; }
        public string IMOClass { get; set; }
        public string OOG { get; set; }
        public string DMG { get; set; }
        public string BillNumber { get; set; }
        public string Remarks { get; set; }
        public string Weight { get; set; }
        public string ISO { get; set; }
        public string Voyage { get; set; }
        public DateTime ETA { get; set; }
        public int Status { get; set; } //ContainerStatusEnum

        /// <summary>
        /// ref
        /// </summary>
        public Customer Customer { get; set; }
        public Vessel Vessel { get; set; }
        public ContainerType ContainerType { get; set; }

    }
}
