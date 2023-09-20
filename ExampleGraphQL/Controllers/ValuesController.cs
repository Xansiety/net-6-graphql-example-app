using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello World!" });
        }
    }
}
