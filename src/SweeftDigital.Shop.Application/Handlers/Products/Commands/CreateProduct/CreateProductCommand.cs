﻿using AutoMapper;
using MediatR;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Core.Entities;
using SweeftDigital.Shop.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Products.Commands
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public string PictureUrl { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            await _productRepository.Create(product);

            return Unit.Value;
        }
    }
}
