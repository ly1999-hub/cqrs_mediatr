using CQRSAndMediatRDemo.Sources.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers
{
    [ApiController]
    [Route("api/v1/role/[controller]")]
    public class RoleController : ControllerBase
    {

        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
