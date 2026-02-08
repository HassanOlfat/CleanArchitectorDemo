using CleanArchDemo.Application.UseCases.Orders.GetOrders;
using CleanArchDemo.Application.UseCases.Products.CreateProduct;
using CleanArchDemo.Application.UseCases.Products.GetProducts;
using CleanArchDemo.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchDemo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly GetOrdersUseCase _getProducts;
        private readonly CreateProductUseCase _createProducts;

        public ProductController(
       GetOrdersUseCase getProducts,
            CreateProductUseCase createProducts
        )
        {
            _getProducts = getProducts;
            _createProducts = createProducts;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
           
            var response =await _createProducts.Handle(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _getProducts.HandleAsync();
            return Ok(response);
        }
    }
}
