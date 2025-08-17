using Readers.Models;

namespace Readers.Domain.Entities.GymRats
{
    public class SessaoLeitura
    {

        public string IdSessao { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string CriadoPorUsuario { get; set; } // implementar para usar a entidade Usuario
        public string Livro { get; set; } //implementar para usar a entidade Livro
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public TipoMetaLeitura? TipoMeta { get; set; }

        public bool EhSessaoPublico { get; set; }

        public List<ParticipanteSessao> Participantes { get; set; } = new();
        public string Descricao { get; set; }


        public SessaoLeitura(string titulo, string criadoPorUsuario, string livro, DateTime dataInicio, DateTime dataFim, TipoMetaLeitura? tipoMeta, bool ehSessaoPublico, string descricao)
        {
            IdSessao = Guid.NewGuid().ToString();
            Titulo = titulo;
            CriadoPorUsuario = criadoPorUsuario;
            Livro = livro;
            DataInicio = dataInicio;
            DataFim = dataFim;
            TipoMeta = tipoMeta;
            EhSessaoPublico = ehSessaoPublico;
            Descricao = descricao;
        }
    }


    public enum TipoMetaLeitura
    {
        Paginas = 1,
        Livros = 2,
        Minutos = 3
    }
}
