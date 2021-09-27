using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Repositories
{
    public interface ISectorForCompanyServiceRepository
    {
        Task<Sector> FindSectorByNameAsync(string name);
    }
}
