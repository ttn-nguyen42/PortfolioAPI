using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IResumeRepository
    {
        public Task<Resume?> GetResumeAsync(int id);
    }

    public class ResumeRepository: IResumeRepository
    {
        private readonly PortfolioContext _context;

        public ResumeRepository(PortfolioContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Resume?> GetResumeAsync(int id)
        {
            return await _context.Resumes.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}
