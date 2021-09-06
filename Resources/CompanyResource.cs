using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Resources
{
    public class CompanyResource
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "ISIN is required")]
        [StringLength(12, ErrorMessage = "ISIN value should have 12 alphanumeric characters")]
        [MinLength(12, ErrorMessage = "ISIN value should have 12 alphanumeric characters")]
        public string ISIN { get; set; }

        [Required(ErrorMessage = "Ticker is required")]
        [MaxLength(4, ErrorMessage ="Ticker value can not exceed 4 characters")]
        public string Ticker { get; set; }
    }
}
