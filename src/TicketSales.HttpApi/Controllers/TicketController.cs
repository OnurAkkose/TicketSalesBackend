using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Core.Utilites.Results;
using TicketSales.Entities.Concrete.Tickets;
using TicketSales.Entities.Dtos;
using TicketSales.HttpApi.Core;

namespace TicketSales.HttpApi.Controllers
{
    public class TicketController : BaseController, ITicketService
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpPost("Add")]
        public async Task<IResult> Add(SaveOrUpdateTicket ticket)
        {
            return await _ticketService.Add(ticket);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _ticketService.Delete(id);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<TicketDto> Get(int id)
        {
            return await _ticketService.Get(id);
        }
        [HttpGet]
        public async Task<List<TicketDto>> GetAll()
        {
            return await _ticketService.GetAll();
        }
        [HttpGet("ticketSales/{ticketId}")]
        public async Task<IResult> TicketSale(int ticketId)
        {
            return await _ticketService.TicketSale(ticketId);
        }
        [HttpPut("Update")]
        public async Task<IResult> Update(Ticket ticket)
        {
            return await _ticketService.Update(ticket);
        }
    }
}
