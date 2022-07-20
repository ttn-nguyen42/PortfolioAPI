using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Contexts
{
    public class PortfolioContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SocialMedia> SocialMedias { get; set; } = null!;
        public DbSet<Major> Majors { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;

        private readonly string _serverUrl = string.Empty;
        private readonly string _serverPort = string.Empty;
        private readonly string _databaseName = string.Empty;
        private readonly string _databaseUser = string.Empty;
        private readonly string _databasePassword = string.Empty;

        public PortfolioContext(IConfiguration configuration)
        {
            _serverUrl = configuration["ConnectionSettings:Portfolio:ServerUrl"] ?? throw new ArgumentNullException(nameof(configuration));
            _serverPort = configuration["ConnectionSettings:Portfolio:ServerPort"] ?? throw new ArgumentNullException(nameof(configuration));
            _databaseName = configuration["ConnectionSettings:Portfolio:DatabaseName"] ?? throw new ArgumentNullException(nameof(configuration));
            _databaseUser = configuration["ConnectionSettings:Portfolio:DatabaseUser"] ?? throw new ArgumentNullException(nameof(configuration));
            _databasePassword = configuration["ConnectionSettings:Portfolio:DatabasePassword"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string settings = $"server={_serverUrl}; " +
                    $"port={_serverPort}; " +
                    $"database={_databaseName}; " +
                    $"user={_databaseName}; " +
                    $"password={_databasePassword}";
                builder.UseMySql(settings, ServerVersion.AutoDetect(settings));
            }
        }
    }
}
