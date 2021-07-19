
using System;
using System.Collections.Generic;
using System.Text;
using TicketSales.Core.Entities.Concrete;

namespace TicketSales.Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
