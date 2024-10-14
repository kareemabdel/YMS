using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class ExtraTariffServiceData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Services { get; set; }

        [Required]
        public int BasisId { get; set; }
        public Basis Basis { get; set; }
        public string? Remarks { get; set; }
        public decimal Amount { get; set; }

    }
}
