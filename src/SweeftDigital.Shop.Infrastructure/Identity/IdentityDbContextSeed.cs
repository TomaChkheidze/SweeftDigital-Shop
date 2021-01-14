using Microsoft.AspNetCore.Identity;
using SweeftDigital.Shop.Application.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Identity
{
    public static class IdentityDbContextSeed
    {
        public static async Task SeedUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRole = new IdentityRole("Administrator");

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(adminRole);
            }

            var adminUser = new ApplicationUser { UserName = "admin", Email = "tomachkheidze@gmail.com", FirstName = "Toma", LastName = "Chkheidze" };

            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(adminUser, "admin");
                await userManager.AddToRolesAsync(adminUser, new[] { adminRole.Name });
            }
        }
    }
}
