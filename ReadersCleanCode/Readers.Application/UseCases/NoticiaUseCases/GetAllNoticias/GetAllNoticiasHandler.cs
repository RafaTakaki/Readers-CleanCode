using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Readers.Domain.Interface;

namespace Readers.Application.UseCases.NoticiaUseCases.GetAllNoticias
{
    public sealed class GetAllNoticiasHandler : IRequestHandler<GetAllNoticiasRequest, List<GetAllNoticiasResponse>>
    {
        private readonly INoticiaRepository _noticiaRepository;

        public GetAllNoticiasHandler(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }

        public async Task<List<GetAllNoticiasResponse>> Handle(GetAllNoticiasRequest request, CancellationToken cancellationToken)
        {
            var noticias = await _noticiaRepository.PegarTodasNoticias();

            return noticias.Select(n => new GetAllNoticiasResponse(
                n.Id,
                n.Titulo,
                n.Descricao,
                n.DataPublicacao)).ToList();
        }
    }
}