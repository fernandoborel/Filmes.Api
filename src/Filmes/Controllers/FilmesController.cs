using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Filmes");
    }
}
