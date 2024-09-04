using ChatGPTClone.Application.Features.Auth.Commands.Login;
using ChatGPTClone.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTClone.WebApi.Controllers
{
    public class AuthController : ApiControllerBase
    {
        public AuthController(ISender mediatr) : base(mediatr)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command, cancellationToken));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediatr.Send(command, cancellationToken));
        }
    }
}
