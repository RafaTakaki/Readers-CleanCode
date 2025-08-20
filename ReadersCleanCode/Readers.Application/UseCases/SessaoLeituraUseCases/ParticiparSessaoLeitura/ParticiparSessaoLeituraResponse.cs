using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readers.Application.UseCases.SessaoLeituraUseCases.ParticiparSessaoLeitura
{
    public sealed record ParticiparSessaoLeituraResponse
    {
        public ParticiparSessaoLeituraResponse(bool result)
        {
            Result = result;
        }

        public bool Result { get; set; }

    }
}