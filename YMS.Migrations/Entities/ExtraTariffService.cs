using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class ExtraTariffService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string? Remarks { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
