using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Business.BusinessAspects.Autofac;
using TicketSales.Business.ValidationRules.FluentValidation;
using TicketSales.Constants.Tickets;
using TicketSales.Core.Aspects.Autofac.Caching;
using TicketSales.Core.Aspects.Autofac.Validation;
using TicketSales.Core.Utilites.Results;
using TicketSales.DataAccess.Abstract;
using TicketSales.Entities.Concrete.Companies;
using TicketSales.Entities.Dtos;

namespace TicketSales.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        private readonly IMapper _mapper;
        public CompanyManager(ICompanyDal companyDal, IMapper mapper)
        {
            _companyDal = companyDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public async Task<IResult> Add(Company company)
        {
            await _companyDal.Add(company);
            return new Result(Messages.CompanyAdded);
        }

        public async Task<IResult> Delete(int id)
        {
            var company = await _companyDal.Get(c => c.Id == id);
            await _companyDal.Delete(company);
            return new Result(Messages.CompanyRemoved);
        }

        public async Task<CompanyDto> Get(int id)
        {
            var company = await _companyDal.Get(c => c.Id == id);
            return _mapper.Map<Company, CompanyDto>(company);
        }
        [RedisAspect]
        //[SecuredOperation("company.get,admin")]
        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = await _companyDal.GetList();
            return _mapper.Map<IList<Company>, List<CompanyDto>>(companies);
        }

        public async Task<IResult> Update(Company company)
        {
            await _companyDal.Update(company);
            return new Result(Messages.CompanyUpdated);
        }
    }
}
