using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities.Lookups
{
    public class Block : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Remarks { get; set; }
        public int BlockType { get; set; }
        public bool Full { get; set; }
        public bool IMO { get; set; }
        public bool NonSlot { get; set; }

        [Range(10, 99, ErrorMessage = "The Bay value must be a two-digit integer.")]
        public short Bay { get; set; }

        [Range(10, 99, ErrorMessage = "The Rows value must be a two-digit integer.")]
        public short Rows { get; set; }

        [Range(0, 9, ErrorMessage = "The Tier value must be a one-digit integer.")]
        public short Tier { get; set; }
        public string StartingRow { get; set; }
        public string CellDimension { get; set; }
    }
}
