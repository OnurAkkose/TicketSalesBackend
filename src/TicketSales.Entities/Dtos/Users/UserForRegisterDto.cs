using System;
using System.Linq;
using TicketSales.Core.Entities;

namespace TicketSales.Entities.Dtos.Users
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
