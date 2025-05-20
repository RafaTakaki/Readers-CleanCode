using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readers.Domain.Entities;
using Readers.Models;

namespace Readers.Domain.Interface
{
    public interface ILeituraLancamentoRepository
    {
        Task<bool> LancarLeituraTempo(LeituraLancamento leituraLancamento);
        Task<int> BuscarTotalLeituraMesId(string IdUsuario);

        Task<List<(string UsuarioId, int TotalMinutos)>> BuscarRankingLeituraMensal();

    }
}