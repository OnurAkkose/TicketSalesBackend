using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Utilites.Results;
using TicketSales.Entities.Concrete.Tickets;
using TicketSales.Entities.Dtos;

namespace TicketSales.Business.Abstract
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetAll();
        Task<TicketDto> Get(int id);
        Task<IResult> Update(Ticket ticket);
        Task<IResult> Add(SaveOrUpdateTicket ticket);
        Task<IResult> Delete(int id);
        Task<IResult> TicketSale(int id);
    }
}
