using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.Framework.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message): base(message){ }
    }
}
