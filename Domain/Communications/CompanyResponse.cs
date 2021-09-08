using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Communications
{
    public class CompanyResponse: BaseResponse
    {
        public CompanyResource _companyResource { get; private set; }

        public CompanyResponse(bool success, string errorMessage, CompanyResource companyResource) : base(success, errorMessage)
        {
            _companyResource = companyResource;
        }

        public CompanyResponse(CompanyResource companyResource) : this(true, null, companyResource)
        {
        }

        public CompanyResponse(string message) : this(false, message, null)
        {
        }
    }
}
