using AutoMapper;
using Maripiell.Common.Common.Domain.Common;
using Maripiell.Services.AuthAPI.DataAccess.Repositories.Contracts;
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
        private readonly IUserRepository userRepository;

        public AuthService(UserManager<User> userService, IMapper mapper, IUserRepository userRepository)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var currentUser = userRepository.GetByEmailOrUsername(user.Username) ?? throw new CustomError("User not found");

            if (await userService.CheckPasswordAsync(currentUser, user.Password))
            {
                return new LoginResponse(mapper.Map<LoginDto>(currentUser), "");
            }

            throw new CustomError("Invalid Credentials");

        }

        public async Task<UserDto> Register(UserDto user)
        {
            var userEntity = mapper.Map<User>(user);
            var response = await userService.CreateAsync(userEntity, user.Password);

            if(!response.Succeeded || response.Errors.Any())
            {
                throw new CustomError(AuthIdentityErrorResult.ToString(response.Errors));
            }

            return user;
        }
    }
}
