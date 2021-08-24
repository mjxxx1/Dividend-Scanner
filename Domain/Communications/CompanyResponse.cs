using DividendScanner.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Communications
{
    public class CompanyResponse: BaseResponse
    {
        public Company _company { get; private set; }

        public CompanyResponse(bool success, string errorMessage, Company company) : base(success, errorMessage)
        {
            _company = company;
        }

        public CompanyResponse(Company company) : this(true, null, company)
        {
        }

        public CompanyResponse(string message) : this(false, message, null)
        {
        }
    }
}
