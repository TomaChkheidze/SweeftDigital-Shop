using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Core.ValueObjects;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public string PictureUrl { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IResponseCacheService _cache;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IResponseCacheService cache,
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
            await _productRepository.Update(product);

            var cacheKey = $"{typeof(UpdateProductCommand).Name}|{JsonSerializer.Serialize(request)}";

            await _cache.DeleteCachedResponseAsync(cacheKey);

            _logger.LogInformation($"Removed Cashed Response: {typeof(UpdateProductCommand).Name} | CacheKey: {cacheKey}");

            return Unit.Value;
        }
    }
}
