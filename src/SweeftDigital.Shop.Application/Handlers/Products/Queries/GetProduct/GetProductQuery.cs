using MediatR;
using SweeftDigital.Shop.Application.Attributes;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Queries
{
    [Cached(10)]
    public class GetProductQuery : IRequest<Product>, IHasIdValidator
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.Get(request.Id, cancellationToken);
        }
    }
}
