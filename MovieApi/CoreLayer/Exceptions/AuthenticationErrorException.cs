using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Exceptions
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException() : base("Email and Password not matched")
        {

        }

        public AuthenticationErrorException(string? message) : base(message)
        {

        }

        public AuthenticationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
