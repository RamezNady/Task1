using System.ComponentModel.DataAnnotations;

namespace Task_API.DTO
{
    public class ActorForRegisterDTO
    {
        [Required]
        public string Name { get; set; } 
        
        [Required, StringLength(8, MinimumLength = 4,ErrorMessage="Maenf3sh el klam dah")]
        public string Password { get; set; }
    }
}