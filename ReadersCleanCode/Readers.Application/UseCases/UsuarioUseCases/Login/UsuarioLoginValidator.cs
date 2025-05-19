using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public class UsuarioLoginValidator : AbstractValidator<UsuarioLoginRequest>
    {
        public UsuarioLoginValidator()
        {
            // RuleFor(x => x.Email)
            //     .NotEmpty().WithMessage("Email é obrigatório.")
            //     .EmailAddress().WithMessage("Email inválido.");

            // RuleFor(x => x.Senha)
            //     .NotEmpty().WithMessage("Senha é obrigatória.");
        }
    }
}