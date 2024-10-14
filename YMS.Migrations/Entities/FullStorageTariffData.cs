using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class FullStorageTariffData : StorageTariffData
    {
        [Required]
        public int FulllStorageDataTypeId { get; set; }
        public FullStorageDataType FulllStorageDataType { get; set; }

        [Required]
        public Guid FullStorageTariffId { get; set; }
        public required FullStorageTariff FullStorageTariff { get; set; }
    }
}
