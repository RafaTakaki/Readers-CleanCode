using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.NoticiaUseCases.GetNoticiaUseCases
{
    public class GetNoticiaHandler : IRequestHandler<GetNoticiaRequest, GetNoticiaResponse>
    {
        private readonly INoticiaRepository _noticiaRepository;
        public GetNoticiaHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<GetNoticiaResponse> Handle(GetNoticiaRequest request, CancellationToken cancellationToken)
        {
            var noticia = await _noticiaRepository.PegarNoticia(request.Id);
            if (noticia == null)
            {
                throw new Exception("Notícia não encontrada");
            }

            return new GetNoticiaResponse
            (
                noticia.Id,
                noticia.Titulo,
                noticia.Descricao,
                noticia.DataPublicacao
            );
        }
    }
}