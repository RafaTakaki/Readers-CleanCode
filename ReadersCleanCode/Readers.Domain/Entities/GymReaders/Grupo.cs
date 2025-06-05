using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities.GymReaders
{
    public class Grupo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; } = string.Empty;
        public string CriadoPorUsuarioId { get; set; } = string.Empty;
        public string DesafioLeituraId { get; set; } = string.Empty;
        public List<string> ParticipanteDesafioIds { get; set; } = new();
    }
}