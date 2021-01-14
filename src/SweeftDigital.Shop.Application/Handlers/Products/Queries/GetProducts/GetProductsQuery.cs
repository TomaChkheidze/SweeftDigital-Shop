using AutoMapper;
using MediatR;
using SweeftDigital.Shop.Application.Attributes;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Application.ViewModels;
using SweeftDigital.Shop.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Queries
{
    [Cached(1)]
    public class GetProductsQuery : IRequest<PaginatedList<ProductVm>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedList<ProductVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetPaginated(request.PageIndex, request.PageSize, cancellationToken);

            return new PaginatedList<ProductVm>(_mapper.Map<IEnumerable<ProductVm>>(result.Items), result.TotalCount, result.PageIndex, result.PageSize);
        }
    }
}
