using Readers.Domain.Entities;

namespace Readers.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task<bool> CriarUsuario(Usuario usuario);
        Task<Usuario> ValidarEmail(string email);
    }
}