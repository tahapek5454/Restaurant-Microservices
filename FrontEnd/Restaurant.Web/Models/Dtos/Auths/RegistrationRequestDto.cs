using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models.Dtos.Auths
{
    public class RegistrationRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string RePassword { get; set; }
        [Required]

        public string Role { get; set; }
    }
}
