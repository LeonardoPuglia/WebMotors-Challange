using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Framework.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message): base(message){ }
    }
}
