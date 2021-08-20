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

        async Task<IEnumerable<Company>> ICompanyRepository.ListAsync()
        {
            return await _appDbContext.Companies.ToListAsync();
        }
    }
}
