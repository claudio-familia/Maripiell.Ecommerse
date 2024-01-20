using Maripiell.Common.Common.DataAccess.Repositories;
using Maripiell.Common.Common.DataAccess.Repositories.Contracts;
using Maripiell.Services.CouponAPI.Domain.Models;

namespace Maripiell.Services.CouponAPI.DataAccess.Configuration
{
    public static partial class RepositoriesConfiguration
    {
        public static void AddRespositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Coupon, CouponDBContext>, BaseRepository<Coupon, CouponDBContext>>();
        }
    }
}
