using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities
{
    public class RankingLeituraMensal
    {
        public string UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public int TotalMinutos { get; set; }
    }
}