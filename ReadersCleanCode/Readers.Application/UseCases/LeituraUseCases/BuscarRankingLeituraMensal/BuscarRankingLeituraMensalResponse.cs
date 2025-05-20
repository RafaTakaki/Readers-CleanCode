using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readers.Domain.Entities;

namespace Readers.Application.UseCases.LeituraUseCases.BuscarRankingLeituraMensal
{
    public class BuscarRankingLeituraMensalResponse
{
    public List<RankingLeituraMensal> Ranking { get; set; }
}

}