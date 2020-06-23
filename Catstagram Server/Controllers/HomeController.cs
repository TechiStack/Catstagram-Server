﻿

namespace Catstagram_Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    
   
    public class HomeController : ApiController
    {
        [Route(nameof(Get))]
        [Authorize]
        public IActionResult Get()
        {
            
            return Ok("Ohhooo its my first action");
        }

    }
}
