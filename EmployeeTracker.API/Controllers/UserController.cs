using System.Threading.Tasks;
using EmployeeTracker.Contract.User;
using EmployeeTracker.Core.Entities;
using EmployeeTracker.Domain.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeTracker.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            _logger.LogError("selam dünyalı");
            LoginCommand command = new LoginCommand(model.UserName, model.Password);
            var mediator = await _mediator.Send(command);
            return Ok(new LoginResponseModel { Token = mediator.Token });
        }

        [HttpPost ("register")]
        
        public async Task<IActionResult> Register(RegisterModel model)
        {
            RegisterCommand command = new RegisterCommand(model.Name, model.Surname, model.MailAddress, model.UserName,
                model.Password);
            var mediator = await _mediator.Send(command);
            return Ok(new RegisterResponseModel{Id = mediator.Id, Name = mediator.Name, Surname = mediator.Surname, MailAddress = mediator.MailAddress, UserName = mediator.UserName});
        }
    }
}