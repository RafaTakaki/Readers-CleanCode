using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.LeituraUseCases.BuscarTotalLeituraMesId
{
    public class BuscarTotalLeituraMesIdHandler : IRequestHandler<BuscarTotalLeituraMesIdRequest, BuscarTotalLeituraMesIdResponse>
    {
        private readonly ILeituraLancamentoRepository _leituraLancamentoRepository;
        private readonly IGerenciadorTokenService _gerenciadorTokenService;

        public BuscarTotalLeituraMesIdHandler(ILeituraLancamentoRepository leituraLancamentoRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _leituraLancamentoRepository = leituraLancamentoRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }
        public async Task<BuscarTotalLeituraMesIdResponse> Handle(BuscarTotalLeituraMesIdRequest request, CancellationToken cancellationToken)
        {
            var guid = await _gerenciadorTokenService.BuscarGuidToken(request.Token);
            var result = await _leituraLancamentoRepository.BuscarTotalLeituraMesId(guid);

            return new BuscarTotalLeituraMesIdResponse(result);
        }
    }
}