using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Exceptions
{
    public class TimeNotSetException : Exception
    {
        public TimeNotSetException(string message) : base(message) { }

    }
}
