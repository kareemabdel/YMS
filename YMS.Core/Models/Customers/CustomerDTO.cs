using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers
{
    public class CustomerDTO
    {
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
        public int Type { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactPersonDetails { get; set; }

        [Required]
        public int PaymentType { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public CurrencyDTO Currency { get; set; }

        [Required]
        public int CityId { get; set; }
        public CityDTO City { get; set; }

        [Required]
        public Guid BranchId { get; set; }
        public BranchDTO Branch { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        public EmptyStorageTariffDTO EmptyStorageTariff { get; set; }
        public FullStorageTariffDTO FullStorageTariff { get; set; }
        public ServicesTariffDTO ServicesTariff { get; set; }
        public PackageServicesTariffDTO PackageServicesTariff { get; set; }
    }
}
