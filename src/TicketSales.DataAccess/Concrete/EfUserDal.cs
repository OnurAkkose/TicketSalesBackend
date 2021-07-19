using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.DataAccess.EntityFramework;
using TicketSales.Core.Entities.Concrete;
using TicketSales.DataAccess.Abstract;
using TicketSales.DataAccess.Concrete.Contexts;

namespace TicketSales.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, TicketSalesContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new TicketSalesContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
