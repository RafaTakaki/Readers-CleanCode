using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.DesafioUseCases.CriarDesafioLeitura;
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
        public async Task<IActionResult> RegistrarTempoLeitura([FromBody] CriarDesafioLeituraRequest request)
        {
            //implementar
            return BadRequest();
        }
        
    }
}