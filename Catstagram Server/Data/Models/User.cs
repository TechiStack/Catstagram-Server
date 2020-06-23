
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Catstagram_Server.Data.Models
{
    public class User :IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>(); //childs

    }
}
