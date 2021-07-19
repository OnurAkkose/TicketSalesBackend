using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Core.Utilites.Results;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Dtos;
using TicketSales.HttpApi.Core;

namespace TicketSales.HttpApi.Controllers
{
    public class CompanyController : BaseController, ICompanyService
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("Add")]
        public async Task<IResult> Add(Company company)
        {
            return await _companyService.Add(company);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _companyService.Delete(id);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<CompanyDto> Get(int id)
        {
            return await _companyService.Get(id);
        }
        [HttpGet]
        public async Task<List<CompanyDto>> GetAll()
        {
            return await _companyService.GetAll();
        }
        [HttpPut("Update")]
        public async Task<IResult> Update(Company company)
        {
            return await _companyService.Update(company);
        }
    }
}
