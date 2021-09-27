using AutoMapper;
using DividendScanner.Domain.Communications;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ISectorForCompanyServiceRepository _sectorForCompanyServiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, ISectorForCompanyServiceRepository sectorForCompanyServiceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _sectorForCompanyServiceRepository = sectorForCompanyServiceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company, string sectorName)
        {
            Sector sector;
            if (sectorName != null)
            {
                try
                {
                    sector = await _sectorForCompanyServiceRepository.FindSectorByNameAsync(sectorName);
                    company.Sector = sector;
                }
                catch (Exception ex)
                {
                    return new CompanyResponse("Given sector does not exist in database. Make sure that you typed correct sector. If you want to add company with new sector, add sector firstly.");
                }
            }

            CompanyResponse response;
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();
                CompanyResource companyResource = _mapper.Map<Company, CompanyResource>(company);
                Sector sc = await _sectorForCompanyServiceRepository.FindSectorByNameAsync(sectorName);
                companyResource.Sector = sc?.Name;
                response = new CompanyResponse(companyResource);
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
                CompanyResource companyResource = _mapper.Map<Company, CompanyResource>(currentCompany);
                return new CompanyResponse(companyResource);
            }
            catch(Exception ex)
            {
                return new CompanyResponse($"An error occured during updating: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCategory = _companyRepository.FindCompanyByIdAsync(id);
            if (existingCategory == null)
                return new CompanyResponse("Company of given id does not exist");

            try
            {
                await _companyRepository.DeleteAsync(id);
                await _unitOfWork.CompleteAsync();
                Company company = await _companyRepository.FindCompanyByIdAsync(id);
                CompanyResource companyResource = _mapper.Map<Company, CompanyResource>(company);
                return new CompanyResponse(companyResource);
            }
            catch(Exception ex)
            {
                return new CompanyResponse($"An error occured during deleting company. {ex.Message}");
            }
        }
    }
}
