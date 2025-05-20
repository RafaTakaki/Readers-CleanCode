using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readers.Models;

namespace Readers.Domain.Interface
{
    public interface INoticiaRepository
    {
        Task<bool> CriarNoticia(Noticia noticia);
        Task<Noticia> PegarNoticia(string id);
        Task<List<Noticia>> PegarTodasNoticias();
    
    }
}