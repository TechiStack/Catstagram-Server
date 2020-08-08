

using Catstagram_Server.Features.Cats;
using Catstagram_Server.Infrastructure;
using Catstagram_Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram_Server.Features
{
    public class CatsController : ApiController
    {
        private readonly ICatService catService;
        public CatsController(ICatService catService) => this.catService = catService;

        [HttpPost]
        [Authorize]
       
       public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            string userId = this.User.GetId();
            var Id = await this.catService.Create(model.ImageUrl, model.Description, userId);
            return Created(nameof(this.Create), Id);
        }

    }
}
