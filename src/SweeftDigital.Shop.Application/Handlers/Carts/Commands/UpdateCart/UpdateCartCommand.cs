using MediatR;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Commands
{
    public class UpdateCartCommand : Cart, IRequest<Cart>, IHasCartIdValidator
    {
    }

    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Cart>
    {
        private readonly ICartService _cartService;

        public UpdateCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Cart> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartService.UpdateCartAsync(request);
        }
    }
}
