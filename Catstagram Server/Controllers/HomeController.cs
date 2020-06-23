

namespace Catstagram_Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
       // [Authorize]
        public IActionResult Get()
        {

            return Ok("Its working");
        }

    }
}
