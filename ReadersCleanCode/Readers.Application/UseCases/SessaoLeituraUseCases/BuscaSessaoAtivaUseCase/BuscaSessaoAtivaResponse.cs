using Readers.Domain.Entities.GymRats;

namespace Readers.Application.UseCases.SessaoUseCases.BuscaSessaoAtivaUseCase
{
    public sealed record BuscaSessaoAtivaResponse(List<SessaoLeitura> Sessoes);
}