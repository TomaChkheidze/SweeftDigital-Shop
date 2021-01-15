using MediatR;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Commands
{
    public class RemoveFromCartCommand : CartItemOperation, IRequest<Cart>
    {
    }

    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, Cart>
    {
        private readonly ICartService _cartService;

        public RemoveFromCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<Cart> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            Cart cart;

            if (string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.Secret))
            {
                cart = new Cart();
            }
            else
            {
                cart = await _cartService.GetCartAsync(new Cart(request.Id, request.Secret), cancellationToken);
            }

            if (!cart.Items.Any())
            {
                await _cartService.DeleteCartAsync(cart, cancellationToken);
                return new Cart();
            }

            if (cart.Items.Exists(x => x.Id == request.ItemId))
            {
                var item = cart.Items.First(x => x.Id == request.ItemId);

                if(cart.Items.Count <= 1)
                {
                    await _cartService.DeleteCartAsync(cart, cancellationToken);
                    return new Cart();
                }

                if(item.Quantity <= 1)
                {
                    cart.Items.Remove(item);
                }
                else
                {
                    item.Quantity--;
                }
            }
            else
            {
                return cart;
            }

            return await _cartService.UpdateCartAsync(cart, cancellationToken);
        }
    }
}
