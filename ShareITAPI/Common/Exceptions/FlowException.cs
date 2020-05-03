using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareITAPI.Common.Exceptions
{
    public class FlowException : Exception
    {
        public FlowException(string message) : base(message)
        {

        }
    }
}
