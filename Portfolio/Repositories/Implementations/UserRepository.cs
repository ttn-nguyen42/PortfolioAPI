using Microsoft.EntityFrameworkCore;
using Portfolio.Contexts;
using Portfolio.Entities;
using Portfolio.Repositories.Interfaces;

namespace Portfolio.Repositories.Implementations
{
    public class UserRepository: IUserRepository
    {
        private readonly PortfolioContext _context;

        public UserRepository(PortfolioContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(c => c.Id).ToListAsync();
        }
    }
}
