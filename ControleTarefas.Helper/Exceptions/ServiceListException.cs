using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Helper.Exceptions
{
    [Serializable]
    public class ServiceListException : Exception
    {
        public List<string> Messages { get; set; }
        public ServiceListException() { }
        public ServiceListException(IEnumerable<string> messages)
        {
            Messages = messages.ToList();
        }
        protected ServiceListException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
