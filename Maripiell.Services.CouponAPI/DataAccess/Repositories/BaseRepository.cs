using Maripiell.Services.CouponAPI.DataAccess.Repositories.Contracts;
using Maripiell.Services.CouponAPI.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Maripiell.Services.CouponAPI.DataAccess.Repositories
{
    public class BaseRepository<T>(CouponDBContext context) : IBaseRepository<T> where T : class, IAudityEntity
    {
        private readonly DbSet<T> _DbSet = context.Set<T>();
        private readonly CouponDBContext _context = context;

        public T Add(T entity)
        {
            _DbSet.Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public T Delete(T entity)
        {
            _DbSet.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;

            entity.IsDeleted = true;

            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.AsNoTracking().Where(x => x.IsDeleted == false).ToList();
        }

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public T Update(T entity)
        {
            _DbSet.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;

            _context.SaveChanges();

            return entity;
        }
    }
}
