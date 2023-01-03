using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Security
{
    public class HMACMismatchException : Exception
    {
        public HMACMismatchException() { }

        public HMACMismatchException(string message) : base(message) { }

        public HMACMismatchException(string message, Exception innerException) : base(message, innerException) { }
    }
}
