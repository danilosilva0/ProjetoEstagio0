using ControleTarefas.Entity.Model;
using ControleTarefas.Helper.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Validator.Fluent
{
    public class CadastroTarefaValidator : AbstractValidator<CadastroTarefaModel>
    {
        public CadastroTarefaValidator() 
        {
            RuleFor(tarefa => tarefa.Titulo)
                .NotNull().WithMessage(string.Format(ServiceMessages.Required , "Titulo"))
                .NotEmpty().WithMessage(string.Format(ServiceMessages.Required , "Titulo"))
                .MinimumLength(5).WithMessage(string.Format(ServiceMessages.MinInputSize , "Titulo", 5))
                .MaximumLength(50).WithMessage(string.Format(ServiceMessages.MaxInputSize , "Titulo", 50));
        }
    }
}
