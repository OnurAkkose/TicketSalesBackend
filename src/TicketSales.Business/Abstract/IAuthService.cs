using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities.Concrete;
using TicketSales.Core.Security.Jwt;
using TicketSales.Core.Utilites.Results;
using TicketSales.Entities.Dtos.Users;

namespace TicketSales.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password);
        User Login(UserForLoginDto userForLoginDto);
        Task<IResult> UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
