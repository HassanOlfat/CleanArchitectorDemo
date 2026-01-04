using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello from API!");
    }
}
