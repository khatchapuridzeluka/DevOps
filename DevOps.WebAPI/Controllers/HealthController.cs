using Microsoft.AspNetCore.Mvc;

namespace DevOps.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(new { status = "Healthy" });
    }
}