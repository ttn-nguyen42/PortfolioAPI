using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<ProjectType>> GetProjectTypesAsync();

        public Task<ProjectType?> GetProjectTypeAsync(int id);

        public Task<Project?> GetProjectAsync(int id);

        public void AddProjectType(ProjectType projectType);

        public void AddProject(Project project);

        public void RemoveProject(Project project);

        public Task<bool> SaveChangesAsync();
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioContext _context;

        public ProjectRepository(PortfolioContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        public void AddProjectType(ProjectType projectType)
        {
            _context.ProjectTypes.Add(projectType);
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProjectType?> GetProjectTypeAsync(int id)
        {
            return await _context.ProjectTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ProjectType>> GetProjectTypesAsync()
        {
            return await _context.ProjectTypes.ToListAsync();
        }

        public void RemoveProject(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
