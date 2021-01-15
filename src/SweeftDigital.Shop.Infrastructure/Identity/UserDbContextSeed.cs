using Microsoft.AspNetCore.Identity;
using SweeftDigital.Shop.Application.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Identity
{
    public static class UserDbContextSeed
    {
        public static void SeedUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRole = new IdentityRole("Administrator");

            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            var adminUser = new ApplicationUser { UserName = "admin", Email = "tomachkheidze@gmail.com", FirstName = "Toma", LastName = "Chkheidze" };

            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(adminUser, "admin").GetAwaiter().GetResult();
                userManager.AddToRolesAsync(adminUser, new[] { adminRole.Name }).GetAwaiter().GetResult();
            }
        }
    }
}
