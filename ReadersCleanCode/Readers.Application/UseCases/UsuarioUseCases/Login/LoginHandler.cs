
using MediatR;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}