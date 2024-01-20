using Maripiell.Services.AuthAPI.Domain.Common;
using Maripiell.Services.AuthAPI.Domain.Dto;

namespace Maripiell.Services.AuthAPI.Services.Contracts
{
    public interface IAuthService
    {
        Task<UserDto> Register(UserDto user);
        Task<LoginResponse> Login(LoginUser user);
    }
}
