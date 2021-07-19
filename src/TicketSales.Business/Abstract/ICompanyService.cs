using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSales.Core.Utilites.Results;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Dtos;

namespace TicketSales.Business.Abstract
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAll();
        Task<CompanyDto> Get(int id);
        Task<IResult> Update(Company company);
        Task<IResult> Add(Company company);
        Task<IResult> Delete(int id);
    }
}
