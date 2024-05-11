using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Exceptions
{
    internal class TimeInPastException : Exception
    {
        public TimeInPastException(string message) : base(message) { }
}
}
