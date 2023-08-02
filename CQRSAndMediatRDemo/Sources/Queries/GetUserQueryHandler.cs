using CQRSAndMediatRDemo.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IActionResult>
    {
        public async Task<IActionResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            using (var context = new ProductDBContext())
            {
                var user = await context.users.FindAsync(request.UserId);
                if(user == null)
                {
                    return new NoContentResult();
                }
                else
                {
                    return new ObjectResult(user);
                }
            }
        }
    }
}
