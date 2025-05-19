

namespace Readers.Domain.Entities
{
    public class Usuario
    {
        
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string? Apelido { get; private set; }
        public string? Foto { get; private set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; init; }
        public string QuatroLetras { get; private set; }
        public string TipoUsuario { get; set; }



        public Usuario(string nome, string email, string senha, string? apelido, DateTime? dataNascimento, string quatroLetras)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            CadastroEmail(email);
            CadastroSenha(senha);
            Apelido = apelido;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.UtcNow;
            QuatroLetras = quatroLetras;
            TipoUsuario = "usuario_comum";
        }

        public void CadastroEmail(string email)
        {
            if (!email.Contains("@")) throw new ArgumentException("Email inválido");
            Email = email;
        }

        public void AtualizarEmail(string novoEmail)
        {
            if (!novoEmail.Contains("@")) throw new ArgumentException("Email inválido");
            Email = novoEmail;
        }

        public void CadastroSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("Senha inválida");
            if (senha.Length < 6) throw new ArgumentException("Senha Deve contem no mínimo 6 caracteres");
            Senha = senha;
        }

        public void AtualizarSenha(string senhaAntiga, string senha, string confirmacaoSenha)
        {
            if (string.IsNullOrWhiteSpace(senhaAntiga)) throw new ArgumentException("Senha inválida"); //verificar no banco se a senha antiga é igual a senha cadastrada
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("Senha inválida");
            if (senha != confirmacaoSenha) throw new ArgumentException("Senhas não conferem");
            Senha = senha;
        }

        public void ValidarQuatroLetras(string quatroLetras)
        {
            if (quatroLetras.Length != 4) throw new ArgumentException("Quatro letras inválido"); //verificar API GFT se existe
            QuatroLetras = quatroLetras;
        }

        public void CadastroApelido(string apelido, string nome)
        {
            if (string.IsNullOrWhiteSpace(apelido))
            {
                apelido = nome;
            }
            ;
            Apelido = apelido;
        }


    }
}