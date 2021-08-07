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

        public IActionResult Index()
        {
            return Ok();
        }
    }
}