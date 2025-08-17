using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.DesafioUseCases.CriarDesafioLeitura;
using Readers.Application.UseCases.DesafioUseCases.DetalhesDesafioLeituraUseCase;
using Readers.Application.UseCases.DesafioUseCases.ListarDesafiosLeituraUsuarioUseCases;
using Swashbuckle.AspNetCore.Annotations;

namespace Readers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesafioLeituraController : ControllerBase
    {
        IMediator _mediator;

        public DesafioLeituraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CriarDesafioLeitura")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> CriarDesafioLeitura([FromBody] CriarDesafioLeituraRequest request)
        {
            //implementar
            return BadRequest("Não implementado ainda");
        }

        [HttpGet("ListarDesafiosLeituraUsuario")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> ListarDesafiosLeituraUsuario([FromQuery] ListarDesafiosLeituraUsuarioRequest request)
        {
            //Implementar
            return BadRequest("Não implementado ainda");
        }

        [HttpGet("DetalhesDesafioLeitura/{id}")]
        [Authorize]
        [SwaggerOperation(
            Summary = "",
            Description = "")]
        public async Task<IActionResult> DetalhesDesafioLeitura([FromRoute] string id, [FromQuery] DetalhesDesafioLeituraRequest request)
        {
            //Implementar
            return BadRequest("Não implementado ainda");
        }

        // [HttpPut("AtualizarDesafioLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> AtualizarDesafioLeitura([FromRoute] string id, [FromBody] AtualizarDesafioLeituraRequest request)
        // {
        //     //Implementar
        //     return BadRequest("Não implementado ainda");
        // }

        // [HttpPost("ParticiparDesafioLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> ParticiparDesafioLeitura([FromRoute] string id, [FromBody] ParticiparDesafioLeituraRequest request)
        // {
        //     //Implementar
        //     return BadRequest("Não implementado ainda");
        // }

        // [HttpPost("LancarComentarioDesafioLeitura/{id}")]
        // [Authorize]
        // [SwaggerOperation(
        //     Summary = "",
        //     Description = "")]
        // public async Task<IActionResult> LancarComentarioDesafioLeitura([FromRoute] string id, [FromBody] LancarComentarioDesafioLeituraRequest request)
        // {
        //     //Implementar
        //     return BadRequest("Não implementado ainda");
        // }
    }
}