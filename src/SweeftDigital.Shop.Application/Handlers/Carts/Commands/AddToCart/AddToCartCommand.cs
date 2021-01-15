using AutoMapper;
using MediatR;
using SweeftDigital.Shop.Application.Handlers.Carts.Queries;
using SweeftDigital.Shop.Application.Handlers.Products.Queries;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Commands
{
    public class AddToCartCommand : CartItemOperation, IRequest<Cart>
    {
    }

    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Cart>
    {
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddToCartCommandHandler(ICartService cartService, IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _cartService = cartService;
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<Cart> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.GetCartAsync(new Cart(request.Id, request.Secret), cancellationToken);

            if (cart.Items.Any() && cart.Items.Exists(x => x.Id == request.ItemId))
            {
                cart.Items.First(x => x.Id == request.ItemId).Quantity++;
            }
            else
            {
                var product = await _mediator.Send(new GetProductQuery { Id = request.ItemId }, cancellationToken);
                if (product != null)
                {
                    var item = _mapper.Map<CartItem>(product);
                    item.Quantity = 1;
                    cart.Items.Add(item);
                }
            }

            return await _cartService.UpdateCartAsync(cart, cancellationToken);
        }
    }
}
