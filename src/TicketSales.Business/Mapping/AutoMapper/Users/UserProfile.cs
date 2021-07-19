using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities.Concrete;
using TicketSales.Entities.Dtos.Users;

namespace TicketSales.Business.Mapping.AutoMapper.Users
{
    public class UserProfile : BaseProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
