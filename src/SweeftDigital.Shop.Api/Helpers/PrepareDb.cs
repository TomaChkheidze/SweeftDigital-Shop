using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Infrastructure.Identity;
using SweeftDigital.Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Api.Helpers
{
    public static class PrepareDb
    {
        public static void PrepareSeed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedIdentity(serviceScope.ServiceProvider.GetService<UserDbContext>(),
                    serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>(),
                    serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>());

                SeedShop(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }
        }

        private static void SeedIdentity(UserDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //context.Database.Migrate();

            UserDbContextSeed.SeedUser(userManager, roleManager);
        }

        private static void SeedShop(ApplicationDbContext context)
        {
            //context.Database.Migrate();

            ApplicationDbContextSeed.SeedData(context);
        }

        private static async Task WaitForDb(ApplicationDbContext applicationDb, UserDbContext userDb)
        {
            int maxAttempts = 10;
            var delay = TimeSpan.FromSeconds(10);

            for (int i = 0; i < maxAttempts; i++)
            {
                if (applicationDb.Database.CanConnect() || userDb.Database.CanConnect())
                {
                    return;
                }
                await Task.Delay(delay);
            }

            throw new Exception("Couldn't connect to database");
        }
    }
}
