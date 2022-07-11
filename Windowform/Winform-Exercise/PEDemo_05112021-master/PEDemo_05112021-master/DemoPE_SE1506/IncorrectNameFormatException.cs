using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPE_SE1506
{
    class IncorrectNameFormatException : SystemException
    {
        public string Message = "Your input string is incorrect format.";
    }
}
