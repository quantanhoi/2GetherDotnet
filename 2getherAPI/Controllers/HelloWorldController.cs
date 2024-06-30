using Microsoft.AspNetCore.Mvc;

namespace _2getherAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World");
    }
}