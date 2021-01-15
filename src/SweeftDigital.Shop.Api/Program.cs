using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SweeftDigital.Shop.Infrastructure.Identity;
using SweeftDigital.Shop.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await WaitForDb(services.GetRequiredService<ApplicationDbContext>(), services.GetRequiredService<UserDbContext>());
            }

            await host.RunAsync();
        }

        private static async Task WaitForDb(ApplicationDbContext applicationDb, UserDbContext userDb)
        {
            int maxAttempts = 10;
            var delay = TimeSpan.FromSeconds(10);

            for (int i = 0; i < maxAttempts; i++)
            {
                try
                {
                    applicationDb.Database.Migrate();
                    userDb.Database.Migrate();

                    Console.WriteLine("Successfully migrated databases!");

                    return;
                }
                catch (Exception)
                {
                    if (applicationDb.Database.CanConnect() || userDb.Database.CanConnect())
                    {
                        return;
                    }
                    await Task.Delay(delay);
                }
            }

            throw new Exception("Couldn't connect to database");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
