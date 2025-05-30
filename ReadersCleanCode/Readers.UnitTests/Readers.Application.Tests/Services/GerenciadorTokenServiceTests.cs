
using Microsoft.Extensions.Configuration;
using Moq;
using Readers.Application.Services;
using Readers.Domain.Entities;

namespace Readers.UnitTests.Readers.Application.Tests
{
    public class GerenciadorTokenServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfig;
        private readonly GerenciadorTokenService _service;

        public GerenciadorTokenServiceTests()
        {
            _mockConfig = new Mock<IConfiguration>();

            var jwtSection = new Mock<IConfigurationSection>();
            jwtSection.Setup(x => x["SecretKey"]).Returns("supersegredosecreto1234567890fortedemais");
            jwtSection.Setup(x => x["Issuer"]).Returns("TestIssuer");
            jwtSection.Setup(x => x["Audience"]).Returns("TestAudience");
            jwtSection.Setup(x => x["ExpirationTimeInMinutes"]).Returns("30");

            _mockConfig.Setup(x => x.GetSection("JwtSettings")).Returns(jwtSection.Object);

            _service = new GerenciadorTokenService(_mockConfig.Object);
        }

        [Fact]
        public async Task GerarToken_DeveRetornarTokenValido()
        {
            // Arrange
            var usuario = new Usuario("João", "joao@email.com", "12345678", "Jo", null, "ABCD");

            // Act
            var token = await _service.GerarToken(usuario);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(token));
        }

        [Fact]
        public async Task BuscarGuidToken_DeveRetornarIdCorreto()
        {
            // Arrange
            var usuario = new Usuario("João", "joao@email.com", "12345678", "Jo", null, "ABCD");
            var token = await _service.GerarToken(usuario);

            // Act
            var idExtraido = await _service.BuscarGuidToken(token);

            // Assert
            Assert.Equal(usuario.Id, idExtraido);
        }
        [Fact]
        public async Task BuscarGuidToken_DeveRetornarNullParaTokenInvalido()
        {
            // Arrange
            var tokenInvalido = "tokeninvalido1234567890";
            // Act
            var idExtraido = await _service.BuscarGuidToken(tokenInvalido);

            // Assert
            Assert.Null(idExtraido);
        }
    }
}