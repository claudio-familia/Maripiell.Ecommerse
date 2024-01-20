using Maripiell.Services.CouponAPI.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Maripiell.Services.CouponAPI.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CouponDBContext _DataContext;

        public UnitOfWork(CouponDBContext dataContext)
        {
            _DataContext = dataContext;
        }

        public IDbContextTransaction CreateTransaction()
        {
            return this._DataContext.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return _DataContext.SaveChanges();
        }

        public void Dispose()
        {
            _DataContext?.Dispose();
        }
    }
}
