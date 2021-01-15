using MediatR;
using SweeftDigital.Shop.Application.Exceptions;
using SweeftDigital.Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Account.Commands
{
    public class RegisterCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.RegisterUserAsync(request)) { throw new RegistrationException("could not register user"); }

            return Unit.Value;
        }
    }
}
