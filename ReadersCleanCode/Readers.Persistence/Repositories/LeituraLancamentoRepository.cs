using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }

}