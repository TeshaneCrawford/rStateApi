using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace realEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Hello World");
        }
    }
}
