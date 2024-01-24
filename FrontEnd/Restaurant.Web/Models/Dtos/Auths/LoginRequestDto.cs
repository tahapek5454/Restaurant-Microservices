namespace Restaurant.Web.Models.Dtos.Auths
{
    public class LoginRequestDto
    {
        public string? UserNameOrEmail { get; set; }
        public string? Password { get; set; }
    }
}
