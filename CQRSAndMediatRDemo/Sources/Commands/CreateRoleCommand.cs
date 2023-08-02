using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateRoleCommand :IRequest<IActionResult>
    {
        public string RoleName { get; set; }

    }
}
