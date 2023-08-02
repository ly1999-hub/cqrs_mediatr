using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IActionResult>
    {
        public async Task<IActionResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role();
            role.RoleName = request.RoleName;
            using ( var context =new ProductDBContext())
            {
                try
                {
                    var r =await context.roles.FirstOrDefaultAsync(r => r.RoleName == request.RoleName);
                    
                    if (r != null)
                    {
                        return new ConflictResult();
                    }

                    context.roles.Add(role);
                    await context.SaveChangesAsync();
                    return new ObjectResult(role.Id);
                }
                catch (Exception ex)
                {
                    LogInit.Init(2,ex.Message);
                    return new BadRequestResult();
                }
            }
        }
    }
}
