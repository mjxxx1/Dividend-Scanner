using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Domain.Communications
{
    public abstract class BaseResponse
    {
        public bool _success { get; protected set; }
        public string _message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            _success = success;
            _message = message;
        }
    }
}
