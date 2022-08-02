using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio;
using Portfolio.Contexts;
using Xunit.Abstractions;

namespace Portfolio.IntegrationTest
{
    public class IntegrationBase
    {
        protected HttpClient Client { get; set; } = null!;

        public ITestOutputHelper _logger;

        protected IntegrationBase(ITestOutputHelper logger)
        {
            _logger = logger;
            WebApplicationFactory<Program> app = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    /*
                     * Essentially, the framework clones the Program class
                     * But we do not want to test on a real database
                     * Here, we replace the database context with an in-memory one
                     */
                    ServiceDescriptor? realContextDescriptor = services.SingleOrDefault(c => c.ServiceType == typeof(DbContextOptions<PortfolioContext>));
                    if (realContextDescriptor is not null)
                    {
                        services.Remove(realContextDescriptor);
                    }
                    services.AddDbContext<PortfolioContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestingDb");
                    });

                    //var sp = services.BuildServiceProvider();

                    //using (IServiceScope scope = sp.CreateScope())
                    //{
                    //    var scopedServices = scope.ServiceProvider;
                    //    var db = scopedServices.GetRequiredService<PortfolioContext>();

                    //    db.Database.EnsureCreated();
                    //}
                });
            });

            Client = app.CreateClient();
        }

        protected static T? Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected async static Task<T?> Deserialize<T>(HttpContent content)
        {
            return JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
        }

        protected static StringContent Serialize<T>(T obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}