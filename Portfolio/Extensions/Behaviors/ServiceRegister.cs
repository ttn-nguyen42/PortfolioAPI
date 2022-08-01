﻿using Microsoft.AspNetCore.StaticFiles;
using Portfolio.Contexts;

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
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();    
        }
    }
}
