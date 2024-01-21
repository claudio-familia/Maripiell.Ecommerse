using Maripiell.Services.AuthAPI.DataAccess.Repositories;
using Maripiell.Services.AuthAPI.DataAccess.Repositories.Contracts;
using Maripiell.Services.AuthAPI.Domain.Models;

namespace Maripiell.Services.AuthAPI.DataAccess.Configuration
{
    public static partial class RepositoriesConfiguration
    {
        public static void AddRespositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

