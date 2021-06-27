using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity_User.MyException
{
    public class ValidException : Exception
    {
        public ValidException()
        {
        }

        public ValidException(string message) : base(message)
        {
        }

        public ValidException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
