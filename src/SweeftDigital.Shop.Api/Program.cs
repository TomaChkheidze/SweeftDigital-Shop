using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Infrastructure.Identity;
using SweeftDigital.Shop.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var usercontext = services.GetRequiredService<UserDbContext>();
                    var appcontext = services.GetRequiredService<ApplicationDbContext>();

                    if (usercontext.Database.IsSqlServer())
                    {
                        usercontext.Database.Migrate();
                    }

                    if (appcontext.Database.IsSqlServer())
                    {
                        appcontext.Database.Migrate();
                    }

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await IdentityDbContextSeed.SeedUser(userManager, roleManager);
                    await ApplicationDbContextSeed.SeedData(appcontext);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
