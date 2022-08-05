using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IQualificationRepository
    {
        public Task<Qualification?> GetQualificationAsync(int id);

        public Task<bool> SaveChangesAsync();

        public Task AddQualification(Qualification entity);

        public void DeleteQualification(Qualification entity);
    }
    public class QualificationRepository : IQualificationRepository
    {
        private readonly PortfolioContext _context;

        public QualificationRepository(PortfolioContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddQualification(Qualification entity)
        {
            await _context.Qualifications.AddAsync(entity);
        }

        public void DeleteQualification(Qualification entity)
        {
            _context.Qualifications.Remove(entity);
        }

        public async Task<Qualification?> GetQualificationAsync(int id)
        {
            return await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
