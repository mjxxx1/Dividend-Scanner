using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }
    }
}
