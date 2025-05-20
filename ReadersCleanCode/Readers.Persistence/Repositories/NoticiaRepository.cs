using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Readers.Domain.Interface;
using Readers.Models;

namespace Readers.Persistence.Repositories
{
    public class NoticiaRepository :  INoticiaRepository
    {
        private readonly IMongoCollection<Noticia> _noticias;
        public NoticiaRepository(IMongoDatabase database)
        {
            _noticias = database.GetCollection<Noticia>("Noticias");
        }

        public async Task<bool> CriarNoticia(Noticia noticia)
        {
            try
            {
                await _noticias.InsertOneAsync(noticia);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar notícia: {ex.Message}");
                return false;
            }
        }

        public async Task<Noticia> PegarNoticia(string id)
        {
            try
            {
                var filter = Builders<Noticia>.Filter.Eq(n => n.Id, id);
                return await _noticias.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar notícia: {ex.Message}");
            }
        }

        public async Task<List<Noticia>> PegarTitulos()
        {
            try
            {
                return await _noticias.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar títulos: {ex.Message}");
            }
        }
    }
}