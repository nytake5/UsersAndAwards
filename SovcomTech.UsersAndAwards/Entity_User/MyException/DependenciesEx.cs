using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_User.MyException
{
    public class DependenciesEx : Exception
    {
        public DependenciesEx()
        {
        }

        public DependenciesEx(string message) : base(message)
        {
        }

        public DependenciesEx(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
