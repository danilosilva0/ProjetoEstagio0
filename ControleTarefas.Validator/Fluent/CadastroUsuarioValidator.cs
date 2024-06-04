using ControleTarefas.Entity.Enum;
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
    public class CadastroUsuarioValidator : AbstractValidator<CadastroUsuarioModel>
    {
        public CadastroUsuarioValidator() 
        {
            RuleFor(u => u.Nome)
                .NotNull().WithMessage(string.Format(ServiceMessages.Required , "Nome"))
                .NotEmpty().WithMessage(string.Format(ServiceMessages.Required , "Nome"));

            RuleFor(u => u.Email).EmailAddress().WithMessage(string.Format(ServiceMessages.InvalidInput, "Email"))
                .NotNull().WithMessage(string.Format(ServiceMessages.Required, "Email"))
                .NotEmpty().WithMessage(string.Format(ServiceMessages.Required, "Email"));

            RuleFor(u => u.Perfil)
                .Must(perfil => Enum.IsDefined(typeof(PerfilEnum), perfil)).WithMessage(string.Format(ServiceMessages.InvalidInput, "Perfil"))
                .NotNull().WithMessage(string.Format(ServiceMessages.Required, "Perfil"));
        }
    }
}
