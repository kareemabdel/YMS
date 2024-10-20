using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers
{
    public class TariffDTO
    {
        public Guid Id { get; set; }

        public int TariffType { get; set; }

        public bool Active { get; set; }
        public int DailyCountTimeBase { get; set; }
        public int? FreeTeus { get; set; }
        public decimal? TeuRateDay { get; set; }
        public decimal? On20 { get; set; }
        public decimal? Off20 { get; set; }
        public decimal? Off40 { get; set; }
        public decimal? On40 { get; set; }
        public string? Remarks { get; set; }
        public DateTime ValidTo { get; set; }

        public List<TariffDataDTO>? TariffDataList { get; set; }
        public List<TariffServiceDTO>? TariffServices { get; set; }
    }
}
