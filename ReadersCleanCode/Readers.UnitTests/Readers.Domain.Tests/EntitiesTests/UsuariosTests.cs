
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
            var senha = "123456";
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

        [Theory]
        [InlineData("")]
        [InlineData("semarroba.com")]
        [InlineData("email@")]
        public void NaoDeveAceitarEmailInvalido(string emailInvalido)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", emailInvalido, "123456", "apelido", null, "ABCD"));
        }

        [Fact]
        public void NaoDeveAceitarSenhaCurta()
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
                new Usuario("Nome", "teste@email.com", "123", "apelido", null, "ABCD"));
        }





    }
}