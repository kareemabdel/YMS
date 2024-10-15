using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models.Authentications
{
    public class TokenRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
