using Maripiell.Common.Common.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Maripiell.Common.Common.DataAccess.Repositories.Contracts
{
    public interface IBaseRepository<T, CT> where T : class, IAudityEntity where CT : DbContext
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
