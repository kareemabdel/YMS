using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YMS.Migrations.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
        public bool IsShippingLine { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactPersonDetails { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        public Guid? EmptyStorageTariffId { get; set; }
        public EmptyStorageTariff? EmptyStorageTariff { get; set; }

        public Guid? FullStorageTariffId { get; set; }
        public FullStorageTariff? FullStorageTariff { get; set; }

        public Guid? ServicesTariffId { get; set; }
        public ServicesTariff? ServicesTariff { get; set; }

        public Guid? PackageServicesTariffId { get; set; }
        public PackageServicesTariff? PackageServicesTariff { get; set; }
    }
}
