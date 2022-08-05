namespace Portfolio.Repositories
{
    public interface IActivitiesRepository {
        public Task<IEnumerable<ActivityType>> GetActivityTypesAsync();

        public Task<ActivityType?> GetActivityTypeAsync(int id);

        public Task<Activity?> GetActivityAsync(int id);

        public Task AddActivityType(ActivityType entity);

        public Task AddActivity(Activity entity);

        public void RemoveActivity(Activity entity);

        public Task<bool> SaveChangesAsync();

    }

    public class ActivitiesRepository: IActivitiesRepository
    {
        private readonly PortfolioContext _context;

        public ActivitiesRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task AddActivity(Activity entity)
        {
            await _context.Activities.AddAsync(entity);
        }

        public async Task AddActivityType(ActivityType entity)
        {
            await _context.ActivityTypes.AddAsync(entity);
        }

        public async Task<Activity?> GetActivityAsync(int id)
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ActivityType?> GetActivityTypeAsync(int id)
        {
            return await _context.ActivityTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ActivityType>> GetActivityTypesAsync()
        {
            return await _context.ActivityTypes.ToListAsync();
        }

        public void RemoveActivity(Activity entity)
        {
             _context.Activities.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
