using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_User.MyException
{
    public class ConnectionEx : Exception
    {
        public ConnectionEx()
        {
        }

        public ConnectionEx(string message) : base(message)
        {
        }

        public ConnectionEx(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
