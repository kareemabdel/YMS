﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Users
{
    public class UserCredentialsDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public Guid? BranchId { get; set; }
    }
}
