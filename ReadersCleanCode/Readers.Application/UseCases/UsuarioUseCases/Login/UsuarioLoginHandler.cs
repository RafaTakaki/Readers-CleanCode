
using MediatR;
using Readers.Domain.Entities;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public class UsuarioLoginHandler : IRequestHandler<UsuarioLoginRequest, UsuarioLoginResponse>
    {
        IUsuarioRepository _usuarioRepository;
        IGerenciadorTokenService _gerenciadorTokenService;

        public UsuarioLoginHandler(IUsuarioRepository usuarioRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public Task<UsuarioLoginResponse> Handle(UsuarioLoginRequest request, CancellationToken cancellationToken)
        {
            var usuario = _usuarioRepository.ValidarEmail(request.Email).Result;
            if (usuario.Senha == request.Senha)
            {
                var token = _gerenciadorTokenService.GerarToken(usuario);
                return Task.FromResult(new UsuarioLoginResponse
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