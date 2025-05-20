using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readers.Domain.Entities;

namespace Readers.Domain.Interface
{
    public interface IGerenciadorTokenService
    {
        Task<string> GerarToken(Usuario usuario);
    }
}