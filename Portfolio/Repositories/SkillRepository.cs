using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface ISkillRepository
    {
        public Task<IEnumerable<TechnicalSkillType>> GetSkillTypesAsync();
        public Task<TechnicalSkillType?> GetSkillTypeAsync(int typeId);
        public Task<TechnicalSkill?> GetSkillAsync(int skillId);
        public Task AddSkillType(TechnicalSkillType payload);
        public Task AddSkill(TechnicalSkill payload);
        public void RemoveSkill(TechnicalSkill entity);
        public Task<bool> SaveChangesAsync();
    }

    public class SkillRepository : ISkillRepository
    {
        private readonly PortfolioContext _context;

        public SkillRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task AddSkill(TechnicalSkill payload)
        {
            await _context.TechnicalSkills.AddAsync(payload);
        }

        public async Task AddSkillType(TechnicalSkillType payload)
        {
            await _context.TechnicalSkillTypes.AddAsync(payload);
        }

        public async Task<TechnicalSkill?> GetSkillAsync(int skillId)
        {
            return await _context.TechnicalSkills.FirstOrDefaultAsync(s => s.Id == skillId);
        }

        public async Task<TechnicalSkillType?> GetSkillTypeAsync(int typeId)
        {
            return await _context.TechnicalSkillTypes.FirstOrDefaultAsync(t => t.Id == typeId);
        }

        public async Task<IEnumerable<TechnicalSkillType>> GetSkillTypesAsync()
        {
            return await _context.TechnicalSkillTypes.ToListAsync();
        }

        public void RemoveSkill(TechnicalSkill entity)
        {
            _context.TechnicalSkills.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
