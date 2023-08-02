using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateRoleCommand :IRequest<IActionResult>
    {
        [Required]
        public string RoleName { get; set; }

    }
}
