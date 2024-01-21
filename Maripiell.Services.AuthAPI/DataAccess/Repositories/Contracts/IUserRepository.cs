using Maripiell.Services.AuthAPI.Domain.Models;

namespace Maripiell.Services.AuthAPI.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User? GetById(int id);
        public User? GetByEmailOrUsername(string email);
    }
}
