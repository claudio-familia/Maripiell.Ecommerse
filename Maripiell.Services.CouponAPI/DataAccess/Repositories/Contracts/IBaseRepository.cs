using Maripiell.Services.CouponAPI.Domain.Contracts;

namespace Maripiell.Services.CouponAPI.DataAccess.Repositories.Contracts
{
    public interface IBaseRepository<T> where T : class, IAudityEntity
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
