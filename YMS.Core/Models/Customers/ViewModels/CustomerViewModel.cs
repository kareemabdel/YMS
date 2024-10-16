using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class CustomerViewModel
    {
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
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone1 must contain only numbers.")]
        public string Phone1 { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Phone2 must contain only numbers.")]
        public string? Phone2 { get; set; }

        [RegularExpression(@"^\+[0-9]{9,14}$", ErrorMessage = "Mobile must start with a '+' followed by 9 to 14 digits.")]
        [MinLength(10, ErrorMessage = "Mobile must be at least 10 characters long.")]
        [MaxLength(15, ErrorMessage = "Mobile cannot be more than 15 characters long.")]
        public string? Mobile { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
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

        [Required]
        public int CityId { get; set; }

        public Guid? BranchId { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        public EmptyStorageTariffViewModel? EmptyStorageTariff { get; set; }
        public FullStorageTariffViewModel? FullStorageTariff { get; set; }
        public ServicesTariffViewModel? ServicesTariff { get; set; }
        public PackageServicesTariffViewModel? PackageServicesTariff { get; set; }
    }
}
