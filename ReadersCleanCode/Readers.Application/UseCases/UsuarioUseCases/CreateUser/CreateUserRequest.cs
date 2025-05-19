using MediatR;

namespace Readers.Application.UseCases.UsuarioUseCases.CreateUser
{
    public sealed record CreateUserRequest(
        string Nome,
        string Email,
        string Senha,
        string? Apelido,
        DateTime? DataNascimento,
        string QuatroLetras
    ) : IRequest<CreateUserResponse>;

}