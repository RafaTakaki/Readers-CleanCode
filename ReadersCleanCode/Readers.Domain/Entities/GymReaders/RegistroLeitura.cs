using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities.GymRats
{
    public class RegistroLeitura
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UsuarioId { get; set; } = string.Empty;
        public string LivroId { get; set; } = string.Empty;
        public int PaginasLidas { get; set; }
        public int? MinutosLidos { get; set; }
        public DateTime Data { get; set; }
        public string? SessaoLeituraId { get; set; }
    }
}