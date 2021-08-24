using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Persistence.Contexts;
using DividendScanner.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Company company)
        {
            await _appDbContext.Companies.AddAsync(company);
            await _appDbContext.SaveChangesAsync();
        }

        async Task<IEnumerable<Company>> ICompanyRepository.ListAsync()
        {
            return await _appDbContext.Companies.ToListAsync();
        }
    }
}
