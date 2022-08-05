namespace Portfolio.Repositories
{
    public interface IKeyRepository
    {
        public Task<Key?> FindKeyAsync(string key);
    }

    public class KeyRepository: IKeyRepository
    {
        private readonly KeyContext _context;

        public KeyRepository(KeyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Key?> FindKeyAsync(string key)
        {
            return await _context.Keys.FirstOrDefaultAsync(k => k.Value == key);
        }
    }
}
