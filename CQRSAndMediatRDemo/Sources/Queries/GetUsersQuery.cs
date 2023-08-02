using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetUsersQuery : IRequest<IActionResult>
    {
    }
}
