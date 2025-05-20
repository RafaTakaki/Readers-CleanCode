using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public sealed record UsuarioLoginRequest(
    
        string Email,
        string Senha 
    ) : IRequest<UsuarioLoginResponse>;
}