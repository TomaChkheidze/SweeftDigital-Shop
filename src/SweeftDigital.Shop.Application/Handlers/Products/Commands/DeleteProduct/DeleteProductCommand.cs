using MediatR;
using Newtonsoft.Json;
using SweeftDigital.Shop.Application.Handlers.Products.Queries;
using SweeftDigital.Shop.Application.Handlers.Validators;
using SweeftDigital.Shop.Application.Interfaces;
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
        private readonly IDataCacheService _cache;
        public DeleteProductCommandHandler(IProductRepository productRepository, IDataCacheService cache)
        {
            _productRepository = productRepository;
            _cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);

            var cacheKey = $"{typeof(GetProductQuery).Name}|{JsonConvert.SerializeObject(request)}";

            await _cache.DeleteCachedDataAsync(cacheKey, cancellationToken);

            return Unit.Value;
        }
    }
}
