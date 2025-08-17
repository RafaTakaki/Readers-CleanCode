using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities.GymReaders
{

    public class Comentario
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UsuarioId { get; set; } = string.Empty;

        public TipoComentarioAlvo TipoAlvo { get; set; }
        public string AlvoId { get; set; } = string.Empty; // Pode ser o ID de um livro ou Sessao

        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataPostagem { get; set; } = DateTime.UtcNow;
    }

    public enum TipoComentarioAlvo
    {
        Livro = 1,
        Sessao = 2
    }
}
