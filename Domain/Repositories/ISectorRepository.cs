using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Repositories
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> ListAsync();
        Task AddAsync(Sector sector);
        Task<Sector> FindSectorByIdAsync(int id);
        void Update(Sector sector);
        Task DeleteAsync(int id);
    }
}
