


namespace Catstagram_Server.Features.Identity
{
    using Catstagram_Server.Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Data.Models;
    using System.Net;
  
    using Microsoft.Extensions.Options;
  
    using System.Security.Claims;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;

    public  class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

       
       
        
        public IdentityController(
                                     UserManager<User> userManager,
                                     IOptions<AppSettings> appSettings,
                                     IIdentityService identityService
            )
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }
        [HttpGet]
        [Route(nameof(GET))]
        public ActionResult GET()
        {
            return Ok("its working");
        }

        [HttpPost]
        [Route(nameof(Register))]
        
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User { Email = model.Email, UserName = model.UserName};
            var result = await this.userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {

            var user = await userManager.FindByNameAsync(model.UserName);
            if(user  == null)
            {
                return Unauthorized();
            }
            var PasswordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (!PasswordValid)
            {
                return Unauthorized();
            }
            // generate token that is valid for 7 days
           
            return new LoginResponseModel
            {
                Token = this.identityService.GenreateJwtTokken(
                                                                user.Id,
                                                                user.UserName,
                                                                this.appSettings.secret
                                                                )
            };
        }
        
      

    }
}
