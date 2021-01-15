using AutoMapper;
using SweeftDigital.Shop.Application.Handlers.Products.Commands;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Application.ViewModels;
using SweeftDigital.Shop.Core.Entities;

namespace SweeftDigital.Shop.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, CartItem>();
            CreateMap<Product, ProductVm>();
            CreateMap<ProductVm, CartItem>()
                .ForMember(dest =>
                    dest.Quantity,
                    opt => opt.UseDestinationValue());
            CreateMap<PaginatedList<Product>, PaginatedList<ProductVm>>();
        }
    }
}
