using AutoMapper;
using Maripiell.Services.AuthAPI.Domain.Common;
using Maripiell.Services.AuthAPI.Domain.Dto;
using Maripiell.Services.AuthAPI.Domain.Models;
using Maripiell.Services.AuthAPI.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Maripiell.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userService;
        private readonly IMapper mapper;

        public AuthService(UserManager<User> userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public Task<LoginResponse> Login(LoginUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Register(UserDto user)
        {
            var userEntity = mapper.Map<User>(user);
            var response = await userService.CreateAsync(userEntity, user.Password);

            if(!response.Succeeded || response.Errors.Any())
            {
                throw new Exception(response.Errors.ToString());
            }

            return user;
        }
    }
}
