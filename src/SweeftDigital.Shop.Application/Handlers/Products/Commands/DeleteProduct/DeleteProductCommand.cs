using AutoMapper;
using MediatR;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Commands
{
    public class DeleteProductCommand : IRequest, IHasIdValidator
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
