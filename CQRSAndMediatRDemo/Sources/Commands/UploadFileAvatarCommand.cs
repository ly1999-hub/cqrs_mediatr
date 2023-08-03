using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class UploadFileAvatarCommand :IRequest<IActionResult>
    {
        public IFormFile file { get; set; }
    }
}
