using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IExperienceRepository
    {
        public Task<Experience?> GetExperienceAsync(int id);

        public Task<bool> SaveChangesAsync();

        public void AddExperience(Experience entity);

        public void DeleteExperience(Experience entity);

    }

    public class ExperienceRepository : IExperienceRepository
    {
        private readonly PortfolioContext _context;
        public ExperienceRepository(PortfolioContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddExperience(Experience entity)
        {
            _context.Experiences.Add(entity);
        }

        public void DeleteExperience(Experience entity)
        {
            _context.Experiences.Remove(entity);
        }

        public async Task<Experience?> GetExperienceAsync(int id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
