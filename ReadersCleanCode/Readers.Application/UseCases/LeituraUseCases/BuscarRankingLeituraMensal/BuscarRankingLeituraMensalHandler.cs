using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Readers.Domain.Entities;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.LeituraUseCases.BuscarRankingLeituraMensal
{
    public class BuscarRankingLeituraMensalHandler : IRequestHandler<BuscarRankingLeituraMensalRequest, BuscarRankingLeituraMensalResponse>
    {
        private readonly ILeituraLancamentoRepository _leituraLancamentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public BuscarRankingLeituraMensalHandler(ILeituraLancamentoRepository leituraLancamentoRepository, IUsuarioRepository usuarioRepository)
        {
            _leituraLancamentoRepository = leituraLancamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BuscarRankingLeituraMensalResponse> Handle(BuscarRankingLeituraMensalRequest request, CancellationToken cancellationToken)
        {
            var ranking = await _leituraLancamentoRepository.BuscarRankingLeituraMensal();
            var idsUsuarios = ranking.Select(r => r.UsuarioId).ToList();
            var nomesUsuarios = await _usuarioRepository.BuscarNomesUsuarios(idsUsuarios);
            var lista = ranking.Select(r => new RankingLeituraMensal
            {
                UsuarioId = r.UsuarioId,
                NomeUsuario = nomesUsuarios.ContainsKey(r.UsuarioId) ? nomesUsuarios[r.UsuarioId] : "Desconhecido",
                TotalMinutos = r.TotalMinutos
            }).ToList();

            return new BuscarRankingLeituraMensalResponse
            {
                Ranking = lista
            };
        }
    }
}