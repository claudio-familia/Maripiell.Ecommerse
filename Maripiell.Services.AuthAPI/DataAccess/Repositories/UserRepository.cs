using Maripiell.Services.AuthAPI.DataAccess.Repositories.Contracts;
using Maripiell.Services.AuthAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Maripiell.Services.AuthAPI.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _DbSet;
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
            _DbSet =context.Set<User>();
        }

        public IEnumerable<User> GetAll()
        {
            return _DbSet.AsNoTracking().ToList();
        }

        public User? GetByEmailOrUsername(string email)
        {
            return _DbSet.FirstOrDefault(x => x.Email == email || x.UserName == email);
        }

        public User? GetById(int id)
        {
            return _DbSet.Find(id);
        }
    }
}
