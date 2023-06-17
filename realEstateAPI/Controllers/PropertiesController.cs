using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using realEstateAPI.Data;

namespace realEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly RealEstateDbContext dbContext;

        public PropertiesController(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            // var propertiesDomain = await propertyRepository.GetAllAsync();

            // Return DTOs
            // return Ok(mapper.Map<List<PropertyDto>>(propertiesDomain));
            return Ok("Hello World");
        }
    }
}
