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


        //defining relation with Sector table - company has only one sector, sector can have many companies
        public int? SectorID { get; set; } //when sector is deleted, SectorID will be set to null
        public Sector Sector { get; set; }
    }
}
