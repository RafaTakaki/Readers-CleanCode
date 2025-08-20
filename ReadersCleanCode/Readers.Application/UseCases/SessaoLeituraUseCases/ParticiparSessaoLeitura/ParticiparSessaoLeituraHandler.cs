using MediatR;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.SessaoLeituraUseCases.ParticiparSessaoLeitura
{
    public class ParticiparSessaoLeituraHandler : IRequestHandler<ParticiparSessaoLeituraRequest, ParticiparSessaoLeituraResponse>
    {
        private readonly ISessaoLeituraRepository _sessaoLeituraRepository;
        private readonly IGerenciadorTokenService _gerenciadorTokenService;

        public ParticiparSessaoLeituraHandler(ISessaoLeituraRepository sessaoLeituraRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _sessaoLeituraRepository = sessaoLeituraRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public async Task<ParticiparSessaoLeituraResponse> Handle(ParticiparSessaoLeituraRequest request,
        CancellationToken cancellationToken)
        {
            var IdUsuario = await _gerenciadorTokenService.BuscarGuidToken(request.Token);
            var result = await _sessaoLeituraRepository.ParticiparSessao(IdUsuario, request.IdSessao);
            return new ParticiparSessaoLeituraResponse(true);
            
        }
    }
}