


namespace Catstagram_Server.Features
{
    using Microsoft.AspNetCore.Mvc;
    
    
    [ApiController]
    [Route("[controller]")]
    public abstract  class ApiController : ControllerBase
    {
        
        public ActionResult Index()
        {
            return Ok("");
        }
    }
}
