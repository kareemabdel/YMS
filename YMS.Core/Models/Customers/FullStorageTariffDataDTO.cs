using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class FullStorageTariffDataDTO : StorageTariffDataDTO
    {
        [Required]
        public int FulllStorageDataTypeId { get; set; }
        public FullStorageDataTypeDTO FulllStorageDataType { get; set; }
    }
}
