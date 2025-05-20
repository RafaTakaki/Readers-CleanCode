using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.NoticiaUseCases.GetAllNoticias
{
    public sealed record GetAllNoticiasRequest : IRequest<List<GetAllNoticiasResponse>>;

}