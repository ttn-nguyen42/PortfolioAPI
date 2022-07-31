using Portfolio.Entities;

namespace Portfolio.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
    }
}
