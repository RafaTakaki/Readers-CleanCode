using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Readers.Application.UseCases.UsuarioUseCases.CreateUser;
using Readers.Application.UseCases.UsuarioUseCases.Login;
using Swashbuckle.AspNetCore.Annotations;

namespace Readers.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsuarioController : ControllerBase
    {
        IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Cria um novo usuário",
            Description = "Cria um novo usuário no sistema.")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var usuario = await _mediator.Send(request);
            return Ok(usuario);
        }


        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Realiza o login do usuário",
            Description = "Realiza o login do usuário no sistema.")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
        {

            var usuario = await _mediator.Send(request);
            return Ok(usuario);
        }

    }
}