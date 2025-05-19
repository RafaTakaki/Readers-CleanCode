using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Domain.Interface
{
    public interface IGerenciadorToken
    {
        string GerarToken(string email, string senha);
    }
}