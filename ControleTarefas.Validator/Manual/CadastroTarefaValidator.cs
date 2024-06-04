using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using ControleTarefas.Helper.Exceptions;
using ControleTarefas.Helper.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Validator.Manual
{
    public static class CadastroTarefaValidator
    {
        public static void Validar(CadastroTarefaModel novaTarefa, Tarefa? tarefa)
        {
            var erros = new List<string>();

            if (tarefa != null)
            {
                throw new ServiceException(string.Format(ServiceMessages.ExistentRegister, "Titulo"));
            }
            else
            {
                if (string.IsNullOrEmpty(novaTarefa.Titulo))
                {
                    throw new ServiceException(string.Format(ServiceMessages.Required, "Titulo"));
                }
                else
                {
                    if(novaTarefa.Titulo.Length < 5) throw new ServiceException(string.Format(ServiceMessages.MinInputSize, "Titulo", 5));
                    if(novaTarefa.Titulo.Length > 50) throw new ServiceException(string.Format(ServiceMessages.MaxInputSize, "Titulo", 50));
                }
            }

            if (erros.Any()) throw new ServiceListException(erros);
        }
    }
}
