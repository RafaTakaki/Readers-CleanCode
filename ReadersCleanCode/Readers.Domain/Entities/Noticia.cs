using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Models
{
    public class Noticia
    {
        public string Id { get; init; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }


        public Noticia(string titulo, string descricao)
        {
            Id = Guid.NewGuid().ToString();
            Titulo = titulo;
            Descricao = descricao;
            DataPublicacao = DateTime.UtcNow;
        }
    }
}