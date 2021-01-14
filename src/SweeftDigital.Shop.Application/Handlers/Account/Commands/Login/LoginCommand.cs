using MediatR;
using SweeftDigital.Shop.Application.Exceptions;
using SweeftDigital.Shop.Application.Interfaces;
using SweeftDigital.Shop.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Account.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHanler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginCommandHanler(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.LoginUserAsync(request.Username, request.Password);

            if(user == null) { throw new ForbiddenException(); }

            var accessToken = await _tokenService.GenerateAccessToken(user);

            return new LoginResponse
            {
                Username = user.UserName,
                GivenName = $"{user.FirstName} {user.LastName}",
                AccessToken = accessToken
            };
        }
    }
}
