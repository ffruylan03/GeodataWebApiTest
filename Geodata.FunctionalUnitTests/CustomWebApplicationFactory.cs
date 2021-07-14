using Geodata.WebApi;
using Geodata.WebApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Geodata.FunctionalUnitTests
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
                {

                    // Create a new service provider.
                    var provider = services
                            .AddEntityFrameworkSqlite()
                            .BuildServiceProvider();

                    // Add a database context (ApplicationDbContext) using an in-memory 
                    // database for testing.
                    services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseSqlite("DataSource=WebApiData.db");
                            options.UseInternalServiceProvider(provider);
                        });

                    // Build the service provider.
                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database
                    // context (ApplicationDbContext).
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                        // Ensure the database is created.
                        db.Database.EnsureCreated();

                    }
                });
        }
    }
}
