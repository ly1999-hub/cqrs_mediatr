using CQRSAndMediatRDemo.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery,IActionResult>
    {
        public async Task<IActionResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            using( var context =new ProductDBContext())
            {
                try
                {
                    var users = await context.users.ToListAsync();
                    return new ObjectResult(users);
                }
                catch (Exception ex)
                {
                    LogInit.Init(2, ex.Message);
                    return new NoContentResult();
                }
            }
        }
    }
}
