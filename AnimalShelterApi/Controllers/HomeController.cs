using Microsoft.AspNetCore.Mvc;
namespace MyApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
          return Redirect("/swagger/index.html");
        }
    }
}
