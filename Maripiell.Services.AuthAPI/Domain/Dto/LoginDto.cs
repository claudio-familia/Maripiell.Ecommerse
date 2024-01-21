namespace Maripiell.Services.AuthAPI.Domain.Dto
{
    public class LoginDto
    {
        public string? Fullname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
