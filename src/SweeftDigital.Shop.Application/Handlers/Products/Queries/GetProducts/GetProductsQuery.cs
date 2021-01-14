using MediatR;
using SweeftDigital.Shop.Application.Attributes;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Queries
{
    [Cached(1)]
    public class GetProductsQuery : IRequest<PaginatedList<Product>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PaginatedList<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<PaginatedList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetPaginated(request.PageIndex, request.PageSize, cancellationToken);
        }
    }
}
