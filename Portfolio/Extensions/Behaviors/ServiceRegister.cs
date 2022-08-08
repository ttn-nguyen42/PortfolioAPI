using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Portfolio.Contexts;

namespace Portfolio.Extensions.Behaviors
{
    public class ServiceRegister
    {
        private readonly Config _configuration;
        public ServiceRegister(Config configuration)
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

            /*
             * Docker ENV for "Portfolio" database
             * ConnectionSettings__Portfolio__ServerUrl
             * ConnectionSettings__Portfolio__ServerPort
             * ConnectionSettings__Portfolio__DatabaseName
             * ConnectionSettings__Portfolio__DatabaseUser
             * ConnectionSettings__Portfolio__DatabasePassword
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
             * Docker ENV for "ApiKey" database
             * ConnectionSettings__ApiKey__ServerUrl
             * ConnectionSettings__ApiKey__ServerPort
             * ConnectionSettings__ApiKey__DatabaseName
             * ConnectionSettings__ApiKey__DatabaseUser
             * ConnectionSettings__ApiKey__DatabasePassword
             */

            /*
             * AdminKey
             */
            builder.Services.AddDbContext<KeyContext>();

            /*
             * Repositories
             */
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<IEducationRepository, EducationRepository>();
            builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
            builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
            builder.Services.AddScoped<IVolunteeringRepository, VolunteeringRepository>();
            builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            builder.Services.AddScoped<IKeyRepository, KeyRepository>();

            /*
             * Add browser directory
             */
            builder.Services.AddDirectoryBrowser();

        }
    }
}
