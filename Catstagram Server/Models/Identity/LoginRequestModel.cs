

using System.ComponentModel.DataAnnotations;

namespace Catstagram_Server.Models.Identity
{
    public class LoginRequestModel
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
