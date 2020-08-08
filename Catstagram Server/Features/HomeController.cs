

namespace Catstagram_Server.Features
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    
   
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route(nameof(Get))]
        [Authorize]
        public IActionResult Get()
        {
            
            return Ok("Ohhooo its my first action");
        }

    }
}
