using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomStack
{
    public class CustomStackEventArgs : EventArgs
    {
        public string Message { get; }
        public CustomStackEventArgs(string message)
        {
            Message = message;
        }
    }
}
