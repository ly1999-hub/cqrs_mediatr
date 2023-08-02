using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateUserCommand : IRequest<IActionResult>
    {
        public string username { get;set; }
        public string email { get; set; }
        public string password { get;set; }
       

    }
}
