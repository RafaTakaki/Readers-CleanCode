using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Readers.Domain.Interface;
using Readers.Models;

namespace Readers.Application.UseCases.NoticiaUseCases.CreateNoticiaUseCases
{
    public class CreateNoticiaHandler : IRequestHandler<CreateNoticiaRequest, CreateNoticiaResponse>
    {
        private readonly INoticiaRepository _noticiaRepository;

        public CreateNoticiaHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<CreateNoticiaResponse> Handle(CreateNoticiaRequest request, CancellationToken cancellationToken)
        {
            var noticia = new Noticia
            (
                request.Titulo,
                request.Descricao
            );

            var response = await _noticiaRepository.CriarNoticia(noticia);
            if (!response)
            {
                throw new Exception("Erro ao criar notícia");
            }

            return new CreateNoticiaResponse
            (
                noticia.Id,
                noticia.Titulo,
                noticia.Descricao,
                noticia.DataPublicacao
            );
        }
    }
}