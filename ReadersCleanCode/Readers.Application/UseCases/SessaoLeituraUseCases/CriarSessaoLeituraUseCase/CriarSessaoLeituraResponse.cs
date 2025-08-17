using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura
{
    public sealed record CriarSessaoLeituraResponse
    {
        public string Titulo { get; set; }

        public CriarSessaoLeituraResponse(string titulo)
        {
            Titulo = titulo;
        }

    }
}