﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class EmptyStorageTariffDataDTO : StorageTariffDataDTO
    {
        [Required]
        public Guid EmptyStorageTariffId { get; set; }
        public EmptyStorageTariffDTO EmptyStorageTariff { get; set; }
    }
}