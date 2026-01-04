using Microsoft.AspNetCore.Mvc;
using CleanArchDemo.Application.UseCases.GetProducts;

namespace CleanArchDemo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly GetProductsUseCase _getProducts;

        public ProductController(
       GetProductsUseCase getProducts
        )
        {
            _getProducts = getProducts;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
             var response = _getProducts.Handle();
            return Ok(response);
        }
    }
}
