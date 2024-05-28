using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Common.Exceptions
{
    public class ValidationExeption : Exception
    {
        public ValidationExeption(string message) : base(message) { }
    }
}

