using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Container
{
    public class AddGateInDto
    {
        public string ContainerNo { get; set; }
        public int ContainerTypeId { get; set; }
        public bool IsRORO { get; set; }
        public Guid CustomerId { get; set; }
        public int LineId { get; set; }
        public int TransporterId { get; set; }
        public DateTime GateInDate { get; set; }
        public string TruckNo { get; set; }
        public string DriverMobileNumber { get; set; }
        public string DeliveryCardNo { get; set; }
        public string DriverID { get; set; }
        public int VesselId { get; set; }
        public string Voyage { get; set; }
        public DateTime ETA { get; set; }
        public int EIR { get; set; } 
        public int ContainerShippingStatus { get; set; } 
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
    }
}
