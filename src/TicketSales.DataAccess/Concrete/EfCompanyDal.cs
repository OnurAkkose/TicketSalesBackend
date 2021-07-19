using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.DataAccess.EntityFramework;
using TicketSales.DataAccess.Abstract;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.DataAccess.Concrete.Contexts
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, TicketSalesContext>, ICompanyDal
    {

    }
}
