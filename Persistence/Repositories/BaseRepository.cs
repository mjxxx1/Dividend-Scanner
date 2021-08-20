using DividendScanner.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
