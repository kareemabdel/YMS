﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Customers
{
    public class LookupDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
