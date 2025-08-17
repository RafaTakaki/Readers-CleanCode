using MediatR;
using Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura;
using Readers.Domain.Entities;
using Readers.Domain.Entities.GymRats;

namespace Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura
{
    public sealed record CriarSessaoLeituraRequest(
        string Titulo,
        string CriadoPorUsuario,
        string Livro,
        DateTime DataInicio,
        DateTime DataFim,
        TipoMetaLeitura? TipoMeta,
        bool EhSessaoPublico,
        string Descricao
    ) : IRequest<CriarSessaoLeituraResponse>;
}