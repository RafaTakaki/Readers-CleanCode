using Readers.Domain.Entities;

namespace Readers.Models
{
    public class LeituraLivro
    {
        public string Id { get; init; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public Livro Livro { get; set; }
        public string LivroId { get; set; }
        public DateTime? DataTermino { get; set; }
        public StatusLeituraEnum StatusLeitura { get; set; } // Lendo, Pausado, Concluido, Abandonado

        public enum StatusLeituraEnum
        {
            Lendo,
            Pausado,
            Concluido,
            Abandonado
        }
    }
}