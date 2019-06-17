using System.ComponentModel.DataAnnotations;

namespace Task_API.DTO
{
    public class ActorForLoginDTO
    {
        public string Name { get; set; } 
        public string Password { get; set; }
    }
}