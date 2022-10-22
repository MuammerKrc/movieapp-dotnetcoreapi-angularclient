using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Exceptions
{
    public class UserCreateException:Exception
    {
        public UserCreateException() : base("Kişi oluşturulurken bir hata meydana geldi")
        {

        }

        public UserCreateException(string? message) : base(message)
        {

        }

        public UserCreateException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
