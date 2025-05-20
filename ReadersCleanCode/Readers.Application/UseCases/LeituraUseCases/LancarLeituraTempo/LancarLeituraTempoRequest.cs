using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo
{
    public sealed record LancarLeituraTempoRequest : IRequest<LancarLeituraTempoResponse>
    {
        public DateTime DataLeitura { get; set; }
        public int TempoLeitura { get; set; }
        public string? Token { get; set; }
    };
}