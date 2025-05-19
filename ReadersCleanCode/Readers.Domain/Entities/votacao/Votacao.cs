using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Models.votacao
{
    public class Votacao
    {
        public string Id { get; init; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<Livro> Livros { get; set; } = new List<Livro>();
    }
}