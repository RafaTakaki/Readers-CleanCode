using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.NoticiaUseCases.CreateNoticiaUseCases
{
    public sealed record CreateNoticiaResponse
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public CreateNoticiaResponse(string id, string titulo, string descricao, DateTime dataPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
        }

    }
}