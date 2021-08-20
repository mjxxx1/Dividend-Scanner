using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Model
{
    public class Company
    {
        public string Name { get; set; }
        public string ISIN { get; set; }
        public string Ticker { get; set; }
        public bool IsDeleted { get; set; }
    }
}
