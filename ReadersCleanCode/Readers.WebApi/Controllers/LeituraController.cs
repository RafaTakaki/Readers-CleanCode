using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.LeituraUseCases.BuscarRankingLeituraMensal;
using Readers.Application.UseCases.LeituraUseCases.BuscarTotalLeituraMesId;
using Readers.Application.UseCases.UsuarioUseCases.LancarLeituraTempo;
using Readers.Domain.Interface;

namespace Readers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeituraController : ControllerBase
    {
        IMediator _mediator;

        public LeituraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("TempoLeitura")]
        [Authorize]
        public async Task<IActionResult> LancarLeituraTempo(DateTime dataLeitura, int tempoLeitura)
        {
            var request = new LancarLeituraTempoRequest
            {
                DataLeitura = dataLeitura,
                TempoLeitura = tempoLeitura
            };

            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
            request.Token = token;
            var resultado = await _mediator.Send(request);
            return Ok(resultado);
        }

        [HttpGet("BuscarTotalLeituraMesId")]
        [Authorize]
        public async Task<IActionResult> BuscarTotalLeituraMesId()
        {
            var request = Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
            var resultado = await _mediator.Send(new BuscarTotalLeituraMesIdRequest(request));
            return Ok(resultado);
        }

        [HttpGet("RankingLeituraMes")]
        public async Task<IActionResult> RankingLeituraMes(BuscarRankingLeituraMensalRequest request)
        {
            var resultado = await _mediator.Send(request);

            return Ok(resultado);
        }
    }
}