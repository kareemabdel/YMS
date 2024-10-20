using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Entities
{
    public class TariffService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid TariffId { get; set; }
        public Tariff Tariff { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public int BasisId { get; set; }
        public Basis Basis { get; set; }

        public decimal? Amount20 { get; set; }
        public decimal? Amount40 { get; set; }
        public decimal? Amount { get; set; }
        public string? Remarks { get; set; }
    }
}
