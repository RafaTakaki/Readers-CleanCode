using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.NoticiaUseCases.GetNoticiaUseCases
{
    public sealed record GetNoticiaRequest(string Id) : IRequest<GetNoticiaResponse>;

}