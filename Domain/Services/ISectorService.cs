using DividendScanner.Domain.Communications;
using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Services
{
    public interface ISectorService
    {
        Task<IEnumerable<Sector>> ListAsync();
        Task<SectorResponse> SaveAsync(Sector sector);
        Task<SectorResponse> UpdateAsync(int id, Sector sector);
        Task<SectorResponse> DeleteAsync(int id);
    }
}
