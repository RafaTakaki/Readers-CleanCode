using Readers.Domain.Entities;

namespace Readers.Models
{
    public class LeituraLancamento
    {
        public string Id { get; init; }
        public string UsuarioId { get; set; }
        public DateTime DataLancamento { get; set; }
        public int TempoMinutos { get; set; }


        public LeituraLancamento(string usuarioId, DateTime dataLancamento, int tempoMinutos)
        {
            Id = Guid.NewGuid().ToString();
            UsuarioId = usuarioId;
            DataLancamento = dataLancamento;
            TempoMinutos = tempoMinutos;

        }
    }
}

