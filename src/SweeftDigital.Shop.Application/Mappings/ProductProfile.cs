using AutoMapper;
using SweeftDigital.Shop.Application.Handlers.Products.Commands;
using SweeftDigital.Shop.Application.ViewModels;
using SweeftDigital.Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<Product, ProductVm>()
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => src.Price.ToString()));
        }
    }
}
