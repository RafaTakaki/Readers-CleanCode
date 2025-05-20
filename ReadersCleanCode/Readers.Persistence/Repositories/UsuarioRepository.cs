
using MongoDB.Driver;
using Readers.Domain.Entities;
using Readers.Domain.Interface;

namespace Readers.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        public UsuarioRepository(IMongoDatabase database)
        {
            _usuarios = database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<bool> CriarUsuario(Usuario usuario)
        {
            try
            {
                await _usuarios.InsertOneAsync(usuario);
                return true;
            }
            catch (Exception ex)
            {
                // Aqui você pode registrar o erro ou lidar com ele de outra forma
                Console.WriteLine($"Erro ao criar usuário: {ex.Message}");
                return false;
            }
        }

        public async Task<Usuario> ValidarEmail(string email)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Email, email);
            return await _usuarios.Find(filter).FirstOrDefaultAsync();
        }
    }
}