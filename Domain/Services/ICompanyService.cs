using DividendScanner.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();
    }
}
