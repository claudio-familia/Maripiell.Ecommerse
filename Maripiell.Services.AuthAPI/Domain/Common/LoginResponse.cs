using Maripiell.Services.AuthAPI.Domain.Dto;

namespace Maripiell.Services.AuthAPI.Domain.Common
{
    public class LoginResponse
    {
        public UserDto? User { get; set; }
        public string Token { get; set; }
    }
}
