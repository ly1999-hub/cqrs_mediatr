using CQRSAndMediatRDemo.Sources.Commands;
using CQRSAndMediatRDemo.Sources.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CQRSAndMediatRDemo.Controllers
{
    [ApiController]
    [Route("api/v1/user/[controller]")]
    public class UserController : ControllerBase
    
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var query=new GetUsersQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{UserId:int?}")]
        public async Task<IActionResult> GetUser(int UserId)
        {
            var query=new GetUserQuery();
            query.UserId = UserId;
            return await _mediator.Send(query);
        }
        [HttpPost]
        [Route("upload/file")]
        public async Task<IActionResult> UploadAvatar(IFormFile  file)
        {
            var command = new UploadFileAvatarCommand();
            command.file = file;

            return await _mediator.Send(command); 
        }
    }
}
