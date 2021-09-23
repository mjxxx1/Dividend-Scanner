using DividendScanner.Domain.Model;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Communications
{
    public class SectorResponse: BaseResponse
    {
        public SectorResource _sectorResource { get; private set; }

        public SectorResponse(bool success, string errorMessage, SectorResource sectorResource) : base(success, errorMessage)
        {
            _sectorResource = sectorResource;
        }

        public SectorResponse(SectorResource sectorResource) : this(true, null, sectorResource)
        {
        }

        public SectorResponse(string message) : this(false, message, null)
        {
        }
    }
}
