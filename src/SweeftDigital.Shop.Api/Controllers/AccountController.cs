using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Shop.Application.Handlers.Account.Commands;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
