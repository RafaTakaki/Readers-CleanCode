
using Readers.Domain.Entities;

namespace Readers.UnitTests.Readers.Domain.Tests.EntitiesTests
{
    public sealed class UsuariosTests
    {
         [Fact]
        public void DeveCriarUsuarioComDadosValidos()
        {
            // Arrange
            var nome = "João";
            var email = "joao@email.com";
            var senha = "12345678";
            var apelido = "J";
            var dataNascimento = new DateTime(1990, 1, 1);
            var quatroLetras = "ABCD";

            // Act
            var usuario = new Usuario(nome, email, senha, apelido, dataNascimento, quatroLetras);

            // Assert
            Assert.Equal(nome, usuario.Nome);
            Assert.Equal(email, usuario.Email);
            Assert.Equal(senha, usuario.Senha);
            Assert.Equal(apelido, usuario.Apelido);
            Assert.Equal(dataNascimento, usuario.DataNascimento);
            Assert.Equal(quatroLetras, usuario.QuatroLetras);
            Assert.Equal("usuario_comum", usuario.TipoUsuario);
            Assert.NotNull(usuario.Id);
            Assert.True(usuario.DataCadastro <= DateTime.UtcNow);
        }

        [Fact]
        public void NaoAceitarSenhaVazia()
        {
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", "teste@email.com", "", "apelido", null, "ABCD"));
        }

        [Fact]
        public void NaoAceitarSenhaSemArroba()
        {
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", "teste.email.com", "", "apelido", null, "ABCD"));
        }

        [Fact]
        public void NaoAceitarSenhaComMenosDeOitoCaracteres()
        {
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", "teste@email.com", "1234567", "apelido", null, "ABCD"));
        }

        



        [Theory]
        [InlineData("")]
        [InlineData("12345")]
        [InlineData("1234567")]
        public void NaoDeveAceitarSenhaInvalida(string senhaInvalida)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", "teste@email.com", senhaInvalida, "apelido", null, "ABCD"));
        }


    }
}