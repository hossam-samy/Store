using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command) {

            return Ok(await mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery query)
        {

            return Ok(await mediator.Send(query));
        }
    }
}
