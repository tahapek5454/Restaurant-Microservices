namespace Restaurant.Web.Models.Dtos.Auths
{
    public class RegistrationRequestDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
