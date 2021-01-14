using MediatR;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Commands
{
    public class DeleteCartCommand : IRequest, IHasCartIdValidator
    {
        public string Id { get; set; }
    }

    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly ICartService _cartService;

        public DeleteCartCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            await _cartService.DeleteCartAsync(request.Id);

            return Unit.Value;
        }
    }
}
