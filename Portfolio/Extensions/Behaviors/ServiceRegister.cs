using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Portfolio.Contexts;

namespace Portfolio.Extensions.Behaviors
{
    public class ServiceRegister
    {
        private readonly IConfiguration _configuration;
        public ServiceRegister(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            /*
             * Database contexts
             */
            string _serverUrl = _configuration["ConnectionSettings:Portfolio:ServerUrl"];
            string _serverPort = _configuration["ConnectionSettings:Portfolio:ServerPort"];
            string _databaseName = _configuration["ConnectionSettings:Portfolio:DatabaseName"];
            string _databaseUser = _configuration["ConnectionSettings:Portfolio:DatabaseUser"];
            string _databasePassword = _configuration["ConnectionSettings:Portfolio:DatabasePassword"];

            string settings = $"server={_serverUrl}; " +
                    $"port={_serverPort}; " +
                    $"database={_databaseName}; " +
                    $"user={_databaseUser}; " +
                    $"password={_databasePassword}";

            builder.Services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseLazyLoadingProxies().UseMySql(settings, ServerVersion.AutoDetect(settings));
            });

            /*
             * Repositories
             */
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<IEducationRepository, EducationRepository>();
            builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
            builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
            builder.Services.AddScoped<IVolunteeringRepository, VolunteeringRepository>();
        }
    }
}
