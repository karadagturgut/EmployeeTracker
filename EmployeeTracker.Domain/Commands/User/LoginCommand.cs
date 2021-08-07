using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EmployeeTracker.Infrastructure.Abstractions.Services;
using MediatR;

namespace EmployeeTracker.Domain.Commands.User
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class LoginCommandHandler:IRequestHandler<LoginCommand,LoginCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IAuthenticationService service)
        {
            _authenticationService = service;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            InputRequestDTO model = new InputRequestDTO
            {
                Password = request.Password,
                UserName = request.UserName
            };
            var login = await _authenticationService.Login(model);
            return new LoginCommandResponse { Token = login.Token};
        }
    }
    

    public class LoginCommandResponse
    {
        public string Token { get; set; }
    }
}