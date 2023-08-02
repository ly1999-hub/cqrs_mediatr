using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetUserQuery :IRequest<IActionResult>
    {
        public int UserId { get; set; }
    }
}
