using CleanArchDemo.Application.UseCases.CreateCustomer;
using CleanArchDemo.Application.UseCases.CreateProduct;
using CleanArchDemo.Application.UseCases.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly GetProductsUseCase _getProducts;
        private readonly CreateProductUseCase _createProducts;

        public ProductController(
       GetProductsUseCase getProducts,
            CreateProductUseCase createProducts
        )
        {
            _getProducts = getProducts;
            _createProducts = createProducts;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequest request)
        {
            var response = _createProducts.Handle(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _getProducts.Handle();
            return Ok(response);
        }
    }
}
