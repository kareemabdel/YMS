using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Enums
{
    public enum EnvironmentVariablesEnum
    {
        JWT_ISSUER,
        JWT_AUDIENCE,
        JWT_KEY,
        JWT_ACCESS_TOKEN_EXPIRATION_MINUTES,
        JWT_REFRESH_TOKEN_EXPIRATION_DAYS
    }
}
