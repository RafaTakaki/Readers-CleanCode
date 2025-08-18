using Readers.Domain.Entities.GymRats;

namespace Readers.Domain.Interface
{
    public interface ISessaoLeituraRepository
    {
        public Task<bool> CriarSessaoLeitura(SessaoLeitura sessaoLeitura);
        public Task<List<SessaoLeitura>> BuscaSessaoAtiva();
    }
}