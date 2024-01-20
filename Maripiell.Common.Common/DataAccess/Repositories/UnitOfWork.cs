using Maripiell.Common.Common.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Maripiell.Common.Common.DataAccess.Repositories
{
    public class UnitOfWork<CT> : IUnitOfWork, IDisposable where CT : DbContext
    {
        private readonly CT _DataContext;

        public UnitOfWork(CT dataContext)
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
