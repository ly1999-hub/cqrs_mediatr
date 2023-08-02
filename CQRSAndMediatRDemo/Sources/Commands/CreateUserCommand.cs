using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateUserCommand : IRequest<IActionResult>
    {
        [Required]
        [MaxLength(100)]
        public string username { get;set; }
        [Required]
        [EmailAddress(ErrorMessage ="dinh dang *@gmail.com")]
        public string email { get; set; }
        [Required]
        [MinLength(6,ErrorMessage ="mat khau lon hon 5 ky tu!")]
        public string password { get;set; }
    }
}
