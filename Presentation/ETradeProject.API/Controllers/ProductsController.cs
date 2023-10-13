using ETradeProject.Application.Repositories;
using ETradeProject.Domain.Entities;
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
        IOrderReadRepository _orderReadRepository;
        IOrderWriteRepository _orderWriteRepository;
        ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    _productWriteRepository.AddRangeAsync(new()
        //    {
        //        new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 1",UnitPrice=12,UnitsInStock=22},
        //        new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 2",UnitPrice=13,UnitsInStock=23},
        //        new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 3",UnitPrice=14,UnitsInStock=24},
        //        new(){CreatedDate=DateTime.UtcNow,Id=Guid.NewGuid(),Name="Product 4",UnitPrice=15,UnitsInStock=25},
        //    });
        //    var result = _productWriteRepository.SaveAsync();
        //    return Ok();
        //}

        [HttpGet]
        public void AddCustomerAndOrder()
        {
            var customerID = Guid.NewGuid();

            _customerWriteRepository.AddAsync(new()
            {
                Id = customerID,
                Name = "Test MMC",
                

            });

            _orderWriteRepository.AddAsync(new()
            {
                Address = "Baku",
                CustomerID = customerID,
                Description = "Test Ucun Yaradilir"
            });

            _orderWriteRepository.SaveAsync();

        }
        

        [HttpGet("getcustomer")]
        public async Task GetCustomer()
        {
            Order order =  await _orderReadRepository.GetByIdAsync("04a59e4e-e9bd-4968-8299-1fe9b7cb2ae5");
            order.Address = "Agdash";
            _customerWriteRepository.SaveAsync();

        }



    }
}
