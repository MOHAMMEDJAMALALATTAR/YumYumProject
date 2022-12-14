using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
