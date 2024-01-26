using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumex.Services.Exceptions
{
    public class LumexException : Exception
    {
        public int Code { get; set; }
        public LumexException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
