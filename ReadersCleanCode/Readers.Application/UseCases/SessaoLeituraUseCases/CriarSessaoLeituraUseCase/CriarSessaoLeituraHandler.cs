using MediatR;
using Readers.Domain.Entities.GymRats;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura
{
    public class CriarSessaoLeituraHandler : IRequestHandler<CriarSessaoLeituraRequest, CriarSessaoLeituraResponse>
    {
        private readonly ISessaoLeituraRepository _sessaoLeituraRepository;
        private readonly IGerenciadorTokenService _gerenciadorTokenService;

        public CriarSessaoLeituraHandler(ISessaoLeituraRepository sessaoLeituraRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _sessaoLeituraRepository = sessaoLeituraRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public async Task<CriarSessaoLeituraResponse> Handle(CriarSessaoLeituraRequest request,
        CancellationToken cancellationToken)
        {
            var IdUsuario = await _gerenciadorTokenService.BuscarGuidToken(request.token);
            var sessao = new SessaoLeitura
            (
                request.Titulo,
                IdUsuario,
                request.Livro,
                request.DataInicio,
                request.DataFim,
                request.TipoMeta,
                request.EhSessaoPublico,
                request.Descricao
            );

            var response = await _sessaoLeituraRepository.CriarSessaoLeitura(sessao);

            if (!response)
            {
                throw new Exception("Erro ao criar Sessao");
            }

            return new CriarSessaoLeituraResponse(request.Titulo);
        }

        
    }
}