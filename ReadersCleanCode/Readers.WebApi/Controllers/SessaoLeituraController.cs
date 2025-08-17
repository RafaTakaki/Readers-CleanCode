using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.SessaoUseCases.CriarSessaoLeitura;
using Readers.Application.UseCases.SessaoUseCases.DetalhesSessaoLeituraUseCase;
using Readers.Application.UseCases.SessaoUseCases.ListarSessaosLeituraUsuarioUseCases;
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
        // [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> CriarSessaoLeitura([FromBody] CriarSessaoLeituraRequest request)
        {
            try
            {
                var sessao = await _mediator.Send(request);
                return Ok("Sessao para o livro: " + sessao + " Criado");
            }
            catch
            {
                return BadRequest("Não foi possivel criar a sessao");
            }
        }

        [HttpGet("ListarSessaosLeituraUsuario")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> ListarSessaosLeituraUsuario([FromQuery] ListarSessaosLeituraUsuarioRequest request)
        {
            //Implementar
            return BadRequest("Não implementado ainda");
        }

        [HttpGet("DetalhesSessaoLeitura/{id}")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> DetalhesSessaoLeitura([FromRoute] string id, [FromQuery] DetalhesSessaoLeituraRequest request)
        {
            //Implementar
            return BadRequest("Não implementado ainda");
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

        // [HttpPost("ParticiparSessaoLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> ParticiparSessaoLeitura([FromRoute] string id, [FromBody] ParticiparSessaoLeituraRequest request)
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