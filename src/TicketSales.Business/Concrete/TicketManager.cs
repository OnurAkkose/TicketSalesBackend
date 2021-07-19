using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Business.ValidationRules.FluentValidation;
using TicketSales.Constants.Tickets;
using TicketSales.Core.Aspects.Autofac.Caching;
using TicketSales.Core.Aspects.Autofac.Validation;
using TicketSales.Core.Utilites.Results;
using TicketSales.DataAccess.Abstract;
using TicketSales.Entities.Concrete.Tickets;
using TicketSales.Entities.Dtos;
using TicketSales.MessageBroker.RabbitMQ.Abstract;

namespace TicketSales.Business.Concrete
{
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        private readonly IMapper _mapper;
        private readonly IMessageBroker _messageBroker;
        private readonly ICompanyDal _companyDal;
        public TicketManager(ITicketDal ticketDal, IMapper mapper, ICompanyDal companyDal)
        {
            _ticketDal = ticketDal;
            _mapper = mapper;
            _companyDal = companyDal;
        }
        [ValidationAspect(typeof(TicketValidator))]
        public async Task<IResult> Add(SaveOrUpdateTicket ticket)
        {
            var company = await _companyDal.Get(c => c.Id == ticket.CompanyId);
            var saveTicket = new Ticket()
            {
                CompanyId = company.Id,
                Company = company,
                LastDate = ticket.LastDate,
                Name = ticket.Name,
                Price = ticket.Price,
                SaleDate = ticket.SaleDate,
                ShowDate = ticket.ShowDate

            };
            await _ticketDal.Add(saveTicket);
            return new Result(Messages.TicketAdded);
        }

        public async Task<IResult> Delete(int id)
        {
            var ticket = await _ticketDal.Get(t => t.Id == id);
            await _ticketDal.Delete(ticket);
            return new Result(Messages.TicketRemoved);
        }

        public async Task<TicketDto> Get(int id)
        {
            var ticket = await _ticketDal.Get(t => t.Id == id);
            return _mapper.Map<Ticket, TicketDto>(ticket);
        }
        //[RedisAspect]
        public async Task<List<TicketDto>> GetAll()
        {
            var tickets = await _ticketDal.GetList(true);           
            return _mapper.Map<IList<Ticket>, List<TicketDto>>(tickets);
        }

        public async Task<IResult> TicketSale(int id)
        {
            var ticket = await _ticketDal.Get(t => t.Id == id);
            ticket.SalesCount += 1;
            await _ticketDal.Update(ticket);
            var exchangeName = "ticketsaling";
            var routingKey = "KEY_" + ticket.CompanyId;
            await _messageBroker.Publish(exchangeName, routingKey, ticket);
            return new Result(Messages.TicketPurchased);
        }
        public async Task<IResult> Update(Ticket ticket)
        {
            await _ticketDal.Update(ticket);
            return new Result(Messages.TicketUpdated);
        }
    }
}
