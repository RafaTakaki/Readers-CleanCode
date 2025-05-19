using Readers.Domain.Entities;

namespace Readers.Models
{
    public class LeituraLancamento
    {
        public string Id { get; init; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataLancamento { get; set; }
        public int TempoMinutos { get; set; }
    }
}