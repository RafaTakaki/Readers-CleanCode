using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using Readers.Domain.Entities.GymRats;
using Readers.Domain.Interface;

namespace Readers.Persistence.Repositories
{
    public class SessaoLeituraRepository : ISessaoLeituraRepository
    {
        readonly IMongoCollection<SessaoLeitura> _leituraLancamentoCollection;
        public SessaoLeituraRepository(IMongoDatabase database)
        {
            _leituraLancamentoCollection = database.GetCollection<SessaoLeitura>("SessaoLeitura");
        }


        public async Task<bool> CriarSessaoLeitura(SessaoLeitura sessaoLeitura)
        {

            try
            {
                await _leituraLancamentoCollection.InsertOneAsync(sessaoLeitura);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<List<SessaoLeitura>> BuscaSessaoAtiva()
        {
            var hoje = DateTime.UtcNow;
            var filtro = Builders<SessaoLeitura>.Filter.Gt(x => x.DataFim, hoje);

            return await _leituraLancamentoCollection.Find(filtro).ToListAsync();
        }

        public async Task<bool> ParticiparSessao(string idUsuario, string idSessao)
        {
            try
            {
                var filter = Builders<SessaoLeitura>.Filter.Eq(s => s.Id, idSessao);
                var update = Builders<SessaoLeitura>.Update.AddToSet(s => s.Participantes, idUsuario);
                var result = await _leituraLancamentoCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount == 0)
                {
                    throw new InvalidOperationException("Usuário já participa desta sessão.");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}