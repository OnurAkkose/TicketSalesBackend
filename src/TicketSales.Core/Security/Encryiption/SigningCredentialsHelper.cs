using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace TicketSales.Core.Security.Encryiption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
