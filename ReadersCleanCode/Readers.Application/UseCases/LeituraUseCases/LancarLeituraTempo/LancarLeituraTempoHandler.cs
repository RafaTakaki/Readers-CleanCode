using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using Readers.Application.Services;
using Readers.Domain.Interface;
using Readers.Models;

namespace Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo
{
    public class LancarLeituraTempoHandler : IRequestHandler<LancarLeituraTempoRequest, LancarLeituraTempoResponse>
    {
        private readonly ILeituraLancamentoRepository _leituraLancamentoRepository;
        private readonly IGerenciadorTokenService _gerenciadorTokenService;

        public LancarLeituraTempoHandler(ILeituraLancamentoRepository leituraLancamentoRepository, IGerenciadorTokenService gerenciadorTokenService)
        {
            _leituraLancamentoRepository = leituraLancamentoRepository;
            _gerenciadorTokenService = gerenciadorTokenService;
        }

        public async Task<LancarLeituraTempoResponse> Handle(LancarLeituraTempoRequest request, CancellationToken cancellationToken)
        {

            var guid = await _gerenciadorTokenService.BuscarGuidToken(request.Token);
            LeituraLancamento leituraLancamento = new LeituraLancamento(guid, request.DataLeitura, request.TempoLeitura);
            

            var result = await _leituraLancamentoRepository.LancarLeituraTempo(leituraLancamento);
            if (result)
            {
                return new LancarLeituraTempoResponse();
            }
            else
            {
                throw new Exception("Erro ao lançar leitura");
            }
            
        }
    }
}