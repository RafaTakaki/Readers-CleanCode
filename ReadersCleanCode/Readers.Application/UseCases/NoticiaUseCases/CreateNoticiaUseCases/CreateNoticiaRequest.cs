using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.NoticiaUseCases.CreateNoticiaUseCases
{
    public sealed record CreateNoticiaRequest(
        string Titulo,
        string Descricao) : IRequest<CreateNoticiaResponse>;
}