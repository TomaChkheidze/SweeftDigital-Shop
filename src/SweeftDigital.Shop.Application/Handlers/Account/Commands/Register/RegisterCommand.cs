using MediatR;
using SweeftDigital.Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            await _userService.RegisterUserAsync(request);

            return Unit.Value;
        }
    }
}
