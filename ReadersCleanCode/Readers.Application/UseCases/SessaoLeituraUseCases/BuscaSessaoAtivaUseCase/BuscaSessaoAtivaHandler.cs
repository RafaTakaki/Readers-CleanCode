using MediatR;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.SessaoUseCases.BuscaSessaoAtivaUseCase
{
    public class BuscaSessaoAtivaHandler : IRequestHandler<BuscaSessaoAtivaRequest, BuscaSessaoAtivaResponse>
    {
        private readonly ISessaoLeituraRepository _sessaoLeituraRepository;

        public BuscaSessaoAtivaHandler(ISessaoLeituraRepository sessaoLeituraRepository)
        {
            _sessaoLeituraRepository = sessaoLeituraRepository;
        }

        public async Task<BuscaSessaoAtivaResponse> Handle(BuscaSessaoAtivaRequest request,
        CancellationToken cancellationToken)
        {
            var sessoes = await _sessaoLeituraRepository.BuscaSessaoAtiva();
            return new BuscaSessaoAtivaResponse(sessoes);

        }
    }
}