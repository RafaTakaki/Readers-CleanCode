using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Entities.GymRats
{
    public class DesafioLeitura
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public Guid CriadoPorUsuarioId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public TipoMetaLeitura TipoMeta { get; set; }
        public int ValorMeta { get; set; }

        public bool EhDesafioEmGrupo { get; set; }

        public List<ParticipanteDesafio> Participantes { get; set; } = new();
    }

    public enum TipoMetaLeitura
    {
        Paginas = 1,
        Livros = 2,
        Minutos = 3
    }
}
