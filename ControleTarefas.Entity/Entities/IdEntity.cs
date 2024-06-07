using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Entity.Entities
{
    public abstract class IdEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
