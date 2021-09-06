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
        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        { 
        }

        public async Task AddAsync(Company company)
        {
            await _appDbContext.Companies.AddAsync(company);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _appDbContext.Companies.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Company> FindCompanyByIdAsync(int id)
        {
            return await _appDbContext.Companies.FindAsync(id);
        }

        public void Update(Company company)
        {
            _appDbContext.Companies.Update(company);
        }
    }
}
