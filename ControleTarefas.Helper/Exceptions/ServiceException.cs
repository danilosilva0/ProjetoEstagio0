using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Helper.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException() { }
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, Exception exception) : base(message, exception) { }
    }
}
