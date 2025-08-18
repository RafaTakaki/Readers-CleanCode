using MediatR;

namespace Readers.Application.UseCases.SessaoUseCases.BuscaSessaoAtivaUseCase
{
    public sealed record BuscaSessaoAtivaRequest : IRequest<BuscaSessaoAtivaResponse>;
}