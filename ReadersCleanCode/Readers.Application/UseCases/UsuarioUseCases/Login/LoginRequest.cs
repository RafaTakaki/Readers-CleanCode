using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public sealed record LoginRequest : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}