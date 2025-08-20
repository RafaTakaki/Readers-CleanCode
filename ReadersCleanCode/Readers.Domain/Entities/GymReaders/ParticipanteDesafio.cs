using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities.GymRats
{
    public class ParticipanteSessao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UsuarioId { get; set; } = string.Empty;
        public string SessaoLeituraId { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public int Progresso { get; set; }
        public int Pontuacao { get; set; }
    }
}