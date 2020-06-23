


namespace Catstagram_Server.Controllers
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
