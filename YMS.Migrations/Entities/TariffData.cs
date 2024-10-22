using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Entities
{
    public class TariffData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid TariffId { get; set; }
        public Tariff Tariff { get; set; }

        [Required]
        public int DaysNum { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public int? StorageTypeId { get; set; }
        public StorageType? StorageType { get; set; }
    }
}
