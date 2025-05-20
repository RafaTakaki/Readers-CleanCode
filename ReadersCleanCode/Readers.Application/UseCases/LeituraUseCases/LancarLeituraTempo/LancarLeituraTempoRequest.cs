using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo
{
    public sealed record LancarLeituraTempoRequest : IRequest<LancarLeituraTempoResponse>
    {
        public DateTime DataLeitura { get; set; }
        public int TempoLeitura{ get; set; }
        public string Token { get; set; }
    };
}