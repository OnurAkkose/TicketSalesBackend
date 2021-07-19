using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Dtos;

namespace TicketSales.Business.Mapping.AutoMapper.Companies
{
    public class CompanyProfile: BaseProfile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
