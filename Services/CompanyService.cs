using DividendScanner.Domain.Communications;
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
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            CompanyResponse response;
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                response = new CompanyResponse(company);
            }
            catch(Exception ex)
            {
                response = new CompanyResponse(ex.Message);
            }
            
            return response;
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var currentCompany = await _companyRepository.FindCompanyByIdAsync(id);

            if (currentCompany == null)
                return new CompanyResponse("Company about given id does not exist in database.");

            currentCompany.Name = company.Name;
            currentCompany.Ticker = company.Ticker;
            currentCompany.ISIN = company.ISIN;

            try
            {
                _companyRepository.Update(currentCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(currentCompany);
            }
            catch(Exception ex)
            {
                return new CompanyResponse($"An error occured during updating: {ex.Message}");
            }
        }
    }
}
