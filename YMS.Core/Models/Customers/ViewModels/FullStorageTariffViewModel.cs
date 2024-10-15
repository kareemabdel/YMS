using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers.ViewModels
{
    public class FullStorageTariffViewModel : StorageTariffViewModel
    {
        public List<FullStorageTariffDataViewModel> FullStorageTariffDataList { get; set; }
    }
}
