using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomExceptions
{
    public class LessThenNecessaryException : Exception
    {
        public LessThenNecessaryException(string? paramName) : base(paramName) { }
    }
}
