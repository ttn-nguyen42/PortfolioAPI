using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface ISkillRepository
    {
        public Task<IEnumerable<TechnicalSkillType>> GetSkillTypesAsync();
        public Task<TechnicalSkillType?> GetSkillTypeAsync(int typeId);
        public Task<IEnumerable<TechnicalSkillDescription>> GetSkillDescriptionsAsync();
        public Task<TechnicalSkillDescription?> GetSkillDescriptionAsync(int descId);
        public Task<IEnumerable<TechnicalSkill>> GetSkillsAsync();
        public Task<TechnicalSkill?> GetSkillAsync(int skillId);
        public void AddSkillType(TechnicalSkillType payload);
        public void AddSkillDescription(TechnicalSkillDescription payload);
        public void AddSkill(TechnicalSkill payload);
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

        public void AddSkillDescription(TechnicalSkillDescription payload)
        {
            _context.TechnicalSkillDescriptions.Add(payload);
        }

        public void AddSkillType(TechnicalSkillType payload)
        {
            _context.TechnicalSkillTypes.Add(payload);
        }

        public async Task<TechnicalSkill?> GetSkillAsync(int skillId)
        {
            return await _context.TechnicalSkills.FirstOrDefaultAsync(s => s.Id == skillId);
        }

        public async Task<TechnicalSkillDescription?> GetSkillDescriptionAsync(int descId)
        {
            return await _context.TechnicalSkillDescriptions.FirstOrDefaultAsync(d => d.Id == descId);
        }

        public async Task<IEnumerable<TechnicalSkillDescription>> GetSkillDescriptionsAsync()
        {
            return await _context.TechnicalSkillDescriptions.ToListAsync();
        }

        public async Task<IEnumerable<TechnicalSkill>> GetSkillsAsync()
        {
            return await _context.TechnicalSkills.ToListAsync();
        }

        public async Task<TechnicalSkillType?> GetSkillTypeAsync(int typeId)
        {
            return await _context.TechnicalSkillTypes.FirstOrDefaultAsync(t => t.Id == typeId);
        }

        public async Task<IEnumerable<TechnicalSkillType>> GetSkillTypesAsync()
        {
            return await _context.TechnicalSkillTypes.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
