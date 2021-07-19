using System;
using System.Linq;
using TicketSales.Core.DataAccess.EntityFramework;
using TicketSales.DataAccess.Abstract;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.DataAccess.Concrete.Contexts
{
    public class EfTicketDal : EfEntityRepositoryBase<Ticket, TicketSalesContext>, ITicketDal
    {

    }
}
