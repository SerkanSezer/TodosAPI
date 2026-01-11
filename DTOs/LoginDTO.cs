using System.ComponentModel.DataAnnotations;

namespace TodosAPI.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
