using System.Threading.Tasks;
using EmployeeTracker.Contract.User;
using EmployeeTracker.Domain.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTracker.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
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