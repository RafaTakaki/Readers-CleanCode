using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo
{
    public class LancarLeituraTempoValidator : AbstractValidator<LancarLeituraTempoRequest>
    {
        public LancarLeituraTempoValidator()
        {
            
        }
    }
}