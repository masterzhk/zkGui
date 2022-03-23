using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkGui
{
    public class BreakException : Exception
    {
        public BreakException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
