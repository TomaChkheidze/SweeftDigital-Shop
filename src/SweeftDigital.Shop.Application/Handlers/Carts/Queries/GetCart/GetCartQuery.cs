using MediatR;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Queries
{
    public class GetCartQuery : IRequest<Cart>
    {
        public string Id { get; set; }
        public string Secret { get; set; }
    }

    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Cart>
    {
        private readonly ICartService _cartService;

        public GetCartQueryHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Cart> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Id) || string.IsNullOrEmpty(request.Secret))
            {
                return new Cart();
            }
            var cart = new Cart(request.Id, request.Secret);
            return await _cartService.GetCartAsync(cart, cancellationToken);
        }
    }
}
