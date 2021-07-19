using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.Name).NotEmpty();            
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
