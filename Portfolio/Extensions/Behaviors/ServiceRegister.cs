using Microsoft.AspNetCore.StaticFiles;
using Portfolio.Contexts;
using Portfolio.Repositories.Implementations;
using Portfolio.Repositories.Interfaces;

namespace Portfolio.Extensions.Behaviors
{
    public static class ServiceRegister
    {
        public static void Register(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            /*
             * Database contexts
             */
            builder.Services.AddDbContext<PortfolioContext>();

            /*
             * Repositories
             */
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
