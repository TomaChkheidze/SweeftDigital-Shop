using AutoMapper;
using MediatR;
using SweeftDigital.Shop.Application.Attributes;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.ViewModels;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Queries
{
    [Cached(10)]
    public class GetProductQuery : IRequest<ProductVm>, IHasIdValidator
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductVm>(await _productRepository.Get(request.Id, cancellationToken));
        }
    }
}
