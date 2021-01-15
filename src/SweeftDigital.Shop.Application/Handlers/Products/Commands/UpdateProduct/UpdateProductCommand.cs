using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SweeftDigital.Shop.Application.Handlers.Products.Queries;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDataCacheService _cache;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IDataCacheService cache,
            ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(product);

            var cacheKey = $"{typeof(GetProductQuery).Name}|{JsonConvert.SerializeObject(request)}";

            await _cache.DeleteCachedDataAsync(cacheKey, cancellationToken);

            _logger.LogInformation($"Removed Cashed Response: {typeof(UpdateProductCommand).Name} | CacheKey: {cacheKey}");

            return Unit.Value;
        }
    }
}
