using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.UsuarioUseCases.Login
{
    public class UsuarioLoginResponse
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
 
    }
}