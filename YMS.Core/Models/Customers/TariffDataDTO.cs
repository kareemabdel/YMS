﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Models.Customers
{
    public class TariffDataDTO
    {
        public Guid Id { get; set; }
        public int DaysNum { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public StorageTypeDTO? StorageType { get; set; }
    }
}