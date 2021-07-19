using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities;

namespace TicketSales.Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetList(bool includes = false);
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
