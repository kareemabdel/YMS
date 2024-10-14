using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class Tariff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Type { get; set; }
        public DateTime? ValidTo { get; set; }

        //true by default
        public bool Active { get; set; }
        public string? Remarks { get; set; }
        public int? FreeTeus { get; set; }
        public decimal? TeuRateDay { get; set; }
        public decimal? On20 { get; set; }
        public decimal? Off20 { get; set; }
        public decimal? Off40 { get; set; }
        public decimal? On40 { get; set; }
        public int DailyCount { get; set; }

    }
}
