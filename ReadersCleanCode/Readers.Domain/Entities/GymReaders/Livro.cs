using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Models
{
    public class Livro
    {
        public string Id { get; init; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? Descricao { get; set; }
        public string? Capa { get; set; }
        public string Isbn { get; set; }
        public Tipo EhLivro { get; set; } // Livro ou Quadrinho
        public string CapaUrl {get; set; } = string.Empty;
        public int Paginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Editora { get; set; } = string.Empty;

        public enum Tipo
        {
            Livro,
            Quadrinho
        }
    }
}