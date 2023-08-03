using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class UploadFileAvatarCommandHandler : IRequestHandler<UploadFileAvatarCommand, IActionResult>
    {
        public async Task<IActionResult> Handle(UploadFileAvatarCommand request, CancellationToken cancellationToken)
        {
            if(request.file==null|| request.file.Length == 0)
            {
                return new BadRequestObjectResult("File null or Empty !");
            }
            try
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(request.file.FileName);
                string pathFile = Path.Combine("Uploads/", fileName);
                using (var stream = new FileStream(pathFile, FileMode.Create))
                {
                    await request.file.CopyToAsync(stream);
                }
                return new OkObjectResult(pathFile);
            }
            catch (Exception ex)
            {
                LogInit.Init(2, "Error Upload Avatar: " + ex.Message);
                return new  BadRequestObjectResult("Internal Server Error!");
            }
        }
    }
}
