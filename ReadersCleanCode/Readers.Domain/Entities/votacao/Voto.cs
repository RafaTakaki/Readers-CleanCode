
using Readers.Domain.Entities;

namespace Readers.Models.votacao
{
    public class Voto
    {
        public string Id { get; init; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public Votacao Votacao { get; set; }
        public string VotacaoId { get; set; }
        public string Votos { get; set; } 
    }
}