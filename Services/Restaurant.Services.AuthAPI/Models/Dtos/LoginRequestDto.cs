namespace Restaurant.Services.AuthAPI.Models.Dtos
{
    public class LoginRequestDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
