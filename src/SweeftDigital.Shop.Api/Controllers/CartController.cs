using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Shop.Application.Handlers.Carts.Commands;
using SweeftDigital.Shop.Application.Handlers.Carts.Queries;
using SweeftDigital.Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api.Controllers
{
    public class CartController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Cart>> GetCart(string id, string secret)
        {
            return await Mediator.Send(new GetCartQuery { Id = id, Secret = secret });
        }

        [HttpPost("add")]
        public async Task<ActionResult<Cart>> AddToCart(AddToCartCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("remove")]
        public async Task<ActionResult<Cart>> RemoveFromCart(RemoveFromCartCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
