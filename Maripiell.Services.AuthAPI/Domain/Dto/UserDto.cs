namespace Maripiell.Services.AuthAPI.Domain.Dto
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
    }
}
