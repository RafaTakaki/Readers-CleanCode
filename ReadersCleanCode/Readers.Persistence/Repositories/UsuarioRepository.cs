
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

        public async Task<Dictionary<string, string>> BuscarNomesUsuarios(IEnumerable<string> usuariosIds)
        {
            var filter = Builders<Usuario>.Filter.In(u => u.Id, usuariosIds.ToList());
            var usuariosList = await _usuarios.Find(filter).ToListAsync();
            return usuariosList.ToDictionary(u => u.Id, u => u.Nome);
        }
    }
}