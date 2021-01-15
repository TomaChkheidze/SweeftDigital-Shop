using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Infrastructure.Identity;
using SweeftDigital.Shop.Infrastructure.Persistence;
using SweeftDigital.Shop.Infrastructure.Repositories;
using SweeftDigital.Shop.Infrastructure.Services;
using System;
using System.Text;

namespace SweeftDigital.Shop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), b =>
                    {
                        b.EnableRetryOnFailure();

                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    }));

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("IdentityConnection"), b =>
                    {
                        b.EnableRetryOnFailure();

                        b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName);
                    }));

            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                        ValidIssuer = configuration["JWT:Issuer"]
                    };
                });


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IDataCacheService, DataCacheService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
