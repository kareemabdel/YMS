using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Users
{
    public class UserCredentialsModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public int? BranchId { get; set; }
    }
}
