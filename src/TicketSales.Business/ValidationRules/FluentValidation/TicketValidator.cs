using FluentValidation;
using System;
using System.Linq;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.Business.ValidationRules.FluentValidation
{
    public class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Price).GreaterThanOrEqualTo(0);
            RuleFor(t => t.ShowDate).NotEmpty();
        }
    }
}
