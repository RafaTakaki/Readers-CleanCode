using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.UsuarioUseCases.CreateUser
{
    public sealed record CreateUserResponse
    {
        public string Nome { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string? Apelido { get; init; }
        public DateTime? DataNascimento { get; init; }
        public string QuatroLetras { get; init; } = null!;

        public CreateUserResponse(string nome, string email, string? apelido, DateTime? dataNascimento, string quatroLetras)
        {
            Nome = nome;
            Email = email;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            QuatroLetras = quatroLetras;
        }
    }
}