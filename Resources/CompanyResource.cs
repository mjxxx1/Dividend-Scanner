using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Resources
{
    public class CompanyResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(12,
        ErrorMessage = "ISIN should have 12 alphanumeric characters")]
        public string ISIN { get; set; }

        [Required]
        [MaxLength(4)]
        public string Ticker { get; set; }
    }
}
