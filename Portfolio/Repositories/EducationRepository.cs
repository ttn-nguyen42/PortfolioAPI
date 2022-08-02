using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IEducationRepository
    {
        public Task<Education?> GetEducationAsync(int educationId);

        public void AddEducation(Education entity);

        public void DeleteEducation(Education entity);

        public Task<bool> SaveChangesAsync();


    }
    public class EducationRepository : IEducationRepository
    {
        private readonly PortfolioContext _context;
        public EducationRepository(PortfolioContext context)
        {
            _context = context;
        }

        public void AddEducation(Education entity)
        {
            _context.Educations.Add(entity);
        }

        public void DeleteEducation(Education entity)
        {
            _context.Educations.Remove(entity);
        }

        public async Task<Education?> GetEducationAsync(int educationId)
        {
            return await _context.Educations.FirstOrDefaultAsync(e => e.Id == educationId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
