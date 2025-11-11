using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorld : ControllerBase
{
   [HttpGet]
   public IActionResult Get()
   {
      return Ok("Hello World!");
   }

}
