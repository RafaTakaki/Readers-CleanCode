using MongoDB.Driver;
using Readers.Domain.Interface;
using Readers.Models;

namespace Readers.Persistence.Repositories
{
    public class LeituraLancamentoRepository : ILeituraLancamentoRepository
    {
        readonly IMongoCollection<LeituraLancamento> _leituraLancamentoCollection;
        public LeituraLancamentoRepository(IMongoDatabase database)
        {
            _leituraLancamentoCollection = database.GetCollection<LeituraLancamento>("LeituraLancamento");
        }


        public async Task<bool> LancarLeituraTempo(LeituraLancamento leituraLancamento)
        {
            try
            {
                await _leituraLancamentoCollection.InsertOneAsync(leituraLancamento);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<int> BuscarTotalLeituraMesId(string IdUsuario)
        {
            var filtro = Builders<LeituraLancamento>.Filter.And(
        Builders<LeituraLancamento>.Filter.Eq(x => x.UsuarioId, IdUsuario),
        Builders<LeituraLancamento>.Filter.Gte(x => x.DataLancamento, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)),
        Builders<LeituraLancamento>.Filter.Lt(x => x.DataLancamento, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1))
    );

            var resultados = await _leituraLancamentoCollection.Find(filtro).ToListAsync();

            return resultados.Sum(x => x.TempoMinutos);
        }

        public async Task<List<(string UsuarioId, int TotalMinutos)>> BuscarRankingLeituraMensal()
        {
            var now = DateTime.Now;
            var inicioMes = new DateTime(now.Year, now.Month, 1);
            var inicioProximoMes = inicioMes.AddMonths(1);

            var filtro = Builders<LeituraLancamento>.Filter.And(
                Builders<LeituraLancamento>.Filter.Gte(x => x.DataLancamento, inicioMes),
                Builders<LeituraLancamento>.Filter.Lt(x => x.DataLancamento, inicioProximoMes)
            );

            var resultado = await _leituraLancamentoCollection.Aggregate()
                .Match(filtro)
                .Group(
                    x => x.UsuarioId,
                    g => new
                    {
                        UsuarioId = g.Key,
                        TotalMinutos = g.Sum(x => x.TempoMinutos)
                    })
                .SortByDescending(x => x.TotalMinutos)
                .ToListAsync();

            return resultado.Select(r => (r.UsuarioId, r.TotalMinutos)).ToList();
        }
    }

}