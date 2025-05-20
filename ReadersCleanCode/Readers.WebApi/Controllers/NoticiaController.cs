using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.NoticiaUseCases.CreateNoticiaUseCases;

namespace Readers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoticiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CriarNoticia")]
        public async Task<IActionResult> CriarNoticia([FromBody] CreateNoticiaRequest request)
        {
            try
            {
                var noticia = await _mediator.Send(request);
                return Ok(noticia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}