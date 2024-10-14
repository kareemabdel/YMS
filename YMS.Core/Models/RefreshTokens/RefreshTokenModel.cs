using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.RefreshTokens
{
    public class RefreshTokenModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
