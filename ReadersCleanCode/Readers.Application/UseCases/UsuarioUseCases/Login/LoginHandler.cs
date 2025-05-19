
using MediatR;
using Readers.Domain.Entities;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        IUsuarioRepository _usuarioRepository;
        IGerenciadorTokenService _gerenciadorTokenService;

        public LoginHandler(IUsuarioRepository usuarioRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var usuario = _usuarioRepository.ValidarEmail(request.Email).Result;
            if (usuario.Senha == request.Senha)
            {
                var token = _gerenciadorTokenService.GerarToken(usuario);
                return Task.FromResult(new LoginResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Token = token.ToString()
                });
            }
            throw new Exception("Senha inválida");
        }
    }
}