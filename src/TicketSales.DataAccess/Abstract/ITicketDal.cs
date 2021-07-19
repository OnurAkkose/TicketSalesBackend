using System;
using System.Linq;
using TicketSales.Core.DataAccess;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.DataAccess.Abstract
{
    public interface ITicketDal: IEntityRepository<Ticket>
    {

    }
}
