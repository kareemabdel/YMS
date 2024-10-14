using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YMS.Migrations.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

        [Required]
        public string Code { get; set; }
        public string? TaxNumber { get; set; }
        public bool HasVat { get; set; }
        public string? PrintedDataAr { get; set; }
        public string? PrintedDataEn { get; set; }
        public string? Remarks { get; set; }

        [Required]
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string? ContactInformation { get; set; }

        [Required]
        public int Type { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactPersonDetails { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
