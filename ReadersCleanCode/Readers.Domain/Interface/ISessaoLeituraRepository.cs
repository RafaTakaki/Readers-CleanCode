using Readers.Domain.Entities.GymRats;

namespace Readers.Domain.Interface
{
    public interface ISessaoLeituraRepository
    {
        Task<bool> CriarSessaoLeitura(SessaoLeitura sessaoLeitura);
    }
}