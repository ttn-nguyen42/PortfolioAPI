using Portfolio.Utils;

namespace Portfolio.Contexts
{
    public class KeyContext : DbContext
    {
        /*
         * Entities
         */
        public DbSet<Key> Keys { get; set; } = null!;

        /*
         * Server configurations
         */
        private readonly Config _configuration;

        public KeyContext(Config configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string adminKey = _configuration["AdminKey"];

            string hashedKey = KeyHasher.Hash(adminKey);

            builder.Entity<Key>().HasData(new Key(
                1, hashedKey, KeyAuthorization.ADMIN));

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string _keyServerUrl = _configuration["ConnectionSettings:ApiKey:ServerUrl"];
                string _keyServerPort = _configuration["ConnectionSettings:ApiKey:ServerPort"];
                string _keyDatabaseName = _configuration["ConnectionSettings:ApiKey:DatabaseName"];
                string _keyDatabaseUser = _configuration["ConnectionSettings:ApiKey:DatabaseUser"];
                string _keyDatabasePassword = _configuration["ConnectionSettings:ApiKey:DatabasePassword"];

                string apiKeyDatabaseSettings = $"server={_keyServerUrl}; " +
                        $"port={_keyServerPort}; " +
                        $"database={_keyDatabaseName}; " +
                        $"user={_keyDatabaseUser}; " +
                        $"password={_keyDatabasePassword}";

                builder.UseMySql(apiKeyDatabaseSettings, ServerVersion.AutoDetect(apiKeyDatabaseSettings));

            }

        }
    }
}
