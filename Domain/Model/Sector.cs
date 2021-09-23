using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Model
{
    public class Sector
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }


        //defining relation with Company table - company has only one sector, sector can have many companies
        public IList<Company> Companies { get; set; } = new List<Company>();
    }
}
