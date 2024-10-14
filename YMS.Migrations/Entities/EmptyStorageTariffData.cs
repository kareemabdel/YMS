using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class EmptyStorageTariffData : StorageTariffData
    {
        [Required]
        public Guid EmptyStorageTariffId { get; set; }
        public EmptyStorageTariff EmptyStorageTariff { get; set; }
    }
}
