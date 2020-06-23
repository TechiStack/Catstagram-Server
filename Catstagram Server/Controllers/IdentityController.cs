


namespace Catstagram_Server.Controllers
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

       
       
        
        public IdentityController(
                                     UserManager<User> userManager,
                                     IOptions<AppSettings> appSettings
            )
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }
        [Route(nameof(GET))]
        public ActionResult GET()
        {
            return Ok("its working");
        }


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

        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(this.appSettings.secret);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encypttedToken  = tokenHandler.WriteToken(token);
            return new {
                Token = encypttedToken
            };
        }
        
      

    }
}
