﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Entities.Lookups
{
    public class ContainerType:LookupBase
    {
        public int Type { get; set; } //ContainerTypeEnum
        public string? Base64Img { get; set; }
    }
}
