using Maripiell.Services.CouponAPI.DataAccess.Repositories;
using Maripiell.Services.CouponAPI.DataAccess.Repositories.Contracts;
using Maripiell.Services.CouponAPI.Domain.Models;

namespace Maripiell.Services.CouponAPI.DataAccess.Configuration
{
    public static partial class RepositoriesConfiguration
    {
        public static void AddRespositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Coupon>, BaseRepository<Coupon>>();
        }
    }
}
