using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Core.Entities.Concrete;
using TicketSales.DataAccess.Abstract;

namespace TicketSales.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return  _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.Get(u => u.Email == email);
        }
    }
}
