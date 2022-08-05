using Microsoft.AspNetCore.StaticFiles;
using Portfolio.Extensions.Behaviors;
using Portfolio.Extensions.Filters;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Portfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
                                                               .Console().WriteTo
                                                               .File($"Logs/{DateTime.Now.ToString("yyyy/MM/dd")}.txt", rollingInterval: RollingInterval.Day)
                                                               .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                /*
                 * @note: All incommings or outgoings DateTime formats to "MM/yyyy" (i.e 08/2022)
                 */
                options.SerializerSettings.DateFormatString = "MM/yyyy";
            });
            builder.Services.AddControllers(options => { options.Filters.Add<ApiExceptionFilter>(); });
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                ValidationFailureConfigurer.ConfigureValidationFailureOptions(options);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Portfolio API",
                    Description = "ASP.NET Core Web API application for personal portfolio",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHub",
                        Url = new Uri("https://github.com/ttn-nguyen42/PortfolioAPI")
                    },
                });
            });

            /* 
             * User requested services are registered here
             * Database contexts, repositories,...
             */
            ServiceRegister serviceRegister = new ServiceRegister(builder.Configuration);
            serviceRegister.Register(builder);

            builder.Services.AddApiVersioning(setup =>
            {
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setup.ReportApiVersions = true;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run();
        }
    }
}