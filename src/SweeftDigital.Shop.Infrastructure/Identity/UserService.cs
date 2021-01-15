using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweeftDigital.Shop.Application.Exceptions;
using SweeftDigital.Shop.Application.Handlers.Account.Commands;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using SweeftDigital.Shop.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);
            return user.UserName;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ApplicationUser> LoginUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if(user == null)
            {
                throw new AuthException("username is incorrect");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
            {
                throw new AuthException("password is incorrect");
            }

            return user;
        }

        public async Task<bool> RegisterUserAsync(RegisterCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.UserName);

            if (user != null)
            {
                throw new RegistrationException("username already exists");
            }

            var newUser = new ApplicationUser
            {
                UserName = command.UserName,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            var result = await _userManager.CreateAsync(newUser, command.Password);

            return result.Succeeded;
        }
    }
}
