using ETradeProject.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductReadRepository _productReadRepository;
        IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 1",UnitPrice=12,UnitsInStock=22},
                new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 2",UnitPrice=13,UnitsInStock=23},
                new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 3",UnitPrice=14,UnitsInStock=24},
                new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 4",UnitPrice=15,UnitsInStock=25},
            });
            var result = _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
