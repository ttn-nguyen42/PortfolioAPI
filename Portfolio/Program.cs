using Microsoft.AspNetCore.StaticFiles;
using Portfolio.Extensions.Behaviors;
using Portfolio.Extensions.Filters;
using Microsoft.OpenApi.Models;
using Serilog;
using Portfolio.Extensions.Middlewares;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.FileProviders;

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

            /*
             * Service for environment variable retrival
             */
            Config configurator = new Config(builder.Configuration);

            builder.Services.AddSingleton(configurator);

            builder.Host.UseSerilog();

            /*
             * Add directory browsing
             */

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

          /*
           * @note: Enum converter
           */
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
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

                var apiKeySecurityScheme = new OpenApiSecurityScheme()
                {
                    Description = "API key for accessing POST, PUT, DELETE endpoints",
                    Name = "XApiKey",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };

                options.AddSecurityDefinition("XApiKey", apiKeySecurityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "XApiKey"
                        }
                    }, Array.Empty<string>()}
                });

            });

            /* 
             * User requested services are registered here
             * Database contexts, repositories,...
             */
            ServiceRegister serviceRegister = new ServiceRegister(configurator);
            serviceRegister.Register(builder);

            builder.Services.AddApiVersioning(setup =>
            {
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setup.ReportApiVersions = true;
            });

            WebApplication app = builder.Build();

            /*
             * For files
             */
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(builder.Environment.WebRootPath)),
                RequestPath = "/files"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(builder.Environment.WebRootPath)),
                RequestPath = "/files"
            });

            app.UseDirectoryBrowser();

            app.UseSwagger();
            app.UseSwaggerUI();

            MiddlewareSetup setup = new MiddlewareSetup(app);
            setup.RegisterMiddleware();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            /*
             * Database migration
             * Only apply this migration method in monolithic & single-instance apps
             */
            using (var scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                PortfolioContext portfolioContext = services.GetRequiredService<PortfolioContext>();
                KeyContext keyContext = services.GetRequiredService<KeyContext>();
                if (portfolioContext.Database.GetPendingMigrations().Any())
                {
                    portfolioContext.Database.Migrate();
                }
                if (keyContext.Database.GetPendingMigrations().Any())
                {
                    keyContext.Database.Migrate();
                }
            }

            app.Run();
        }
    }
}