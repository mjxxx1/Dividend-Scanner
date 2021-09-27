using AutoMapper;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Persistence.Contexts;
using DividendScanner.Persistence.Repositories;
using DividendScanner.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Persistence.Repositories
{
    public class SectorRepository : BaseRepository, ISectorRepository, ISectorForCompanyServiceRepository
    {
        public SectorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(Sector sector)
        {
            await _appDbContext.Sectors.AddAsync(sector);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sector>> ListAsync()
        {
            return await _appDbContext.Sectors.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public void Update(Sector sector)
        {
            _appDbContext.Sectors.Update(sector);
        }

        public async Task DeleteAsync(int id)
        {
            Sector sector = await FindSectorByIdAsync(id);
            sector.IsDeleted = true;
        }

        public async Task<Sector> FindSectorByIdAsync(int id)
        {
            return await _appDbContext.Sectors.FindAsync(id);
        }

        public async Task<Sector> FindSectorByNameAsync(string name)
        {
            //return await _appDbContext.Sectors.FindAsync(name);
            return await _appDbContext.Sectors.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
