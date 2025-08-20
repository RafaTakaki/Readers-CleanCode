using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.SessaoLeituraUseCases.ParticiparSessaoLeitura;
using Readers.Application.UseCases.SessaoUseCases.BuscaSessaoAtivaUseCase;
using Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura;
using Swashbuckle.AspNetCore.Annotations;

namespace Readers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoLeituraController : ControllerBase
    {
        IMediator _mediator;

        public SessaoLeituraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CriarSessaoLeitura")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> CriarSessaoLeitura([FromBody] CriarSessaoLeituraRequest request)
        {
            try
            {
                var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
                var newRequest = request with { token = jwtToken };
                var sessao = await _mediator.Send(newRequest);
                return Ok("Sessao para o livro: " + sessao + " Criado");
            }
            catch
            {
                return BadRequest("Não foi possivel criar a sessao");
            }
        }

        [HttpGet("BuscaSessaoAtiva")]
        // [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> BuscaSessaoAtiva(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new BuscaSessaoAtivaRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpPost("ParticiparSessaoLeitura")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> ParticiparSessaoLeitura([FromBody] ParticiparSessaoLeituraRequest request)
        {
            var jwtToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "").Trim();
            var newRequest = request with { Token = jwtToken };
            var sessao = await _mediator.Send(newRequest);
            return Ok();
        }

        // [HttpPut("AtualizarSessaoLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> AtualizarSessaoLeitura([FromRoute] string id, [FromBody] AtualizarSessaoLeituraRequest request)
        // {
        //     //Implementar
        //     return BadRequest("Não implementado ainda");
        // }


        // [HttpPost("LancarComentarioSessaoLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> LancarComentarioSessaoLeitura([FromRoute] string id, [FromBody] LancarComentarioSessaoLeituraRequest request)
        // {
        //     //Implementar
        //     return BadRequest("Não implementado ainda");
        // }
    }
}