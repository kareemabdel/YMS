using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class TariffData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }

        public int? Type { get; set; }
        public int DaysNum { get; set; }
        public decimal Amount { get; set; }
        public int Power { get; set; }
    }
}
