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
    public class Branch : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Remarks { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public string? Mobile { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public string? Fax { get; set; }
        public string? Zip { get; set; }
    }
}
