using MediatR;

namespace Readers.Application.UseCases.SessaoLeituraUseCases.ParticiparSessaoLeitura
{
    public sealed record ParticiparSessaoLeituraRequest(    
        string? Token,
        string IdSessao
    ) : IRequest<ParticiparSessaoLeituraResponse>;
}