﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities
{
    public class FullStorageTariff : StorageTariff
    {
        public List<FullStorageTariffData> FullStorageTariffDataList { get; set; }
    }
}