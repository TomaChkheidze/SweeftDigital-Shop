using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Infrastructure.Identity;
using SweeftDigital.Shop.Infrastructure.Persistence;
using SweeftDigital.Shop.Infrastructure.Repositories;
using SweeftDigital.Shop.Infrastructure.Services;

namespace SweeftDigital.Shop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IResponseCacheService, ResponseCacheService>();
            services.AddTransient<ICartService, CartService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization();

            return services;
        }
    }
}
