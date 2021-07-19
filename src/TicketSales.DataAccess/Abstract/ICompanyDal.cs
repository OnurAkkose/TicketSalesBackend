using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.DataAccess;
using TicketSales.Entities.Concrete.Companies;

namespace TicketSales.DataAccess.Abstract
{
    public interface ICompanyDal: IEntityRepository<Company>
    {
    }
}
