using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Entities.Concrete.Tickets;
using TicketSales.Entities.Dtos;

namespace TicketSales.Business.Mapping.AutoMapper.Tickets
{
    public class TicketProfile: BaseProfile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();
        }
    }
}
