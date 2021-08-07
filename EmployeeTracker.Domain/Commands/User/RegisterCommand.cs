using System.Threading;
using System.Threading.Tasks;
using EmployeeTracker.Infrastructure.Abstractions.Services;
using MediatR;

namespace EmployeeTracker.Domain.Commands.User
{
    public class RegisterCommand : IRequest<RegisterCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RegisterCommand(string name, string surname, string mailAddress, string userName, string password)
        {
            Name = name;
            Surname = surname;
            MailAddress = mailAddress;
            UserName = userName;
            Password = password;
        }
    }

    public class UserCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public UserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var model = new RegisterRequestDTO
            {
                Name = request.Name, Surname = request.Surname, MailAddress = request.MailAddress,
                UserName = request.UserName, Password = request.Password
            };
            var register = await _authenticationService.Register(model);
            return new RegisterCommandResponse
            {
                Id = register.Id, Name = register.Name, Surname = register.Surname, MailAddress = register.MailAddress,
                UserName = register.UserName
            };
        }
    }

    public class RegisterCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string UserName { get; set; }
    }
}