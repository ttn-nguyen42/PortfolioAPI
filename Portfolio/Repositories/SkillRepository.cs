using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface ISkillRepository
    {
        public Task<IEnumerable<TechnicalSkillType>> GetSkillTypesAsync();
        public Task<TechnicalSkillType?> GetSkillTypeAsync(int typeId);
        public Task<TechnicalSkill?> GetSkillAsync(int skillId);
        public void AddSkillType(TechnicalSkillType payload);
        public void AddSkill(TechnicalSkill payload);
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

        public void AddSkill(TechnicalSkill payload)
        {
            _context.TechnicalSkills.Add(payload);
        }

        public void AddSkillType(TechnicalSkillType payload)
        {
            _context.TechnicalSkillTypes.Add(payload);
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
