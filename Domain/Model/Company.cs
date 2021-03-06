using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Model
{
    public class Company
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(12,
        ErrorMessage = "ISIN should have 12 alphanumeric characters")]
        public string ISIN { get; set; }
        [Required]
        [MaxLength(4)]
        public string Ticker { get; set; }
        public bool IsDeleted { get; set; }



       // ErrorMessage = "ISIN is required and should be minimum 3 characters and a maximum of 4 characters")]
    }
}
