using Microsoft.EntityFrameworkCore.Storage;

namespace Maripiell.Services.CouponAPI.DataAccess.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IDbContextTransaction CreateTransaction();
        int SaveChanges();
    }
}
