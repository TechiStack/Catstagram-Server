
using System.ComponentModel.DataAnnotations;
using static Catstagram_Server.Data.Validations.Cat;
namespace Catstagram_Server.Data.Models
{
    public class Cat
    {
        public int Id { get; set; }
        
        
        [Required]
        [MaxLength(MaxDescriptionLenght)]
        public string  Description { get; set; }
        [Required]
        
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; } //FK

        public User User { get; set; } //Parent
    }
}
