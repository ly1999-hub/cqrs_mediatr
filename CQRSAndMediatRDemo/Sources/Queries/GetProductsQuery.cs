using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsQuery : IRequest<IActionResult>
    {
    }
}
