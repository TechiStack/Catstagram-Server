

using System.ComponentModel.DataAnnotations;
using static Catstagram_Server.Data.Validations;
namespace Catstagram_Server.Models.Cats
{
    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(Cat.MaxDescriptionLenght)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        
    }
}
