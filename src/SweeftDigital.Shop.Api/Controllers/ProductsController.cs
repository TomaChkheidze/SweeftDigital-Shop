using Microsoft.AspNetCore.Mvc;
using SweeftDigital.Shop.Application.Handlers.Products.Queries;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Application.ViewModels;
using SweeftDigital.Shop.Core.Entities;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductVm>>> GetProducts(int pageIndex = 1, int pageSize = 10)
        {
            return await Mediator.Send(new GetProductsQuery { PageIndex = pageIndex, PageSize = pageSize });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            return await Mediator.Send(new GetProductQuery { Id = id });
        }
    }
}
