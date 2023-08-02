using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IActionResult>
    {
        public async Task<IActionResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User();
            newUser.UserName = request.username;
            newUser.EmailAddress = request.email;
            newUser.Password = request.password;
            newUser.Locked = false;
            newUser.Avatar = "abc";

            newUser.CreatedAt = DateTime.UtcNow.ToUniversalTime();
            newUser.UpdateAt = DateTime.UtcNow.ToUniversalTime();


            using (var context = new ProductDBContext())
            {
                var user = context.users.FirstOrDefault(u => u.EmailAddress == request.email);
                if (user != null) {

                    return new ConflictResult();
                }

                var role = await context.roles.FirstOrDefaultAsync(r => r.RoleName == "USER");
                if(role == null) {
                    return new NotFoundResult();
                }
                newUser.Role = role;
                context.users.Add(newUser);
                await context.SaveChangesAsync();
                return new ObjectResult(newUser);
            }    
        }
    }
}
