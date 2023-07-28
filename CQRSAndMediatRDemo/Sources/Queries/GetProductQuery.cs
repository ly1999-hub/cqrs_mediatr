using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductQuery : IRequest<IActionResult>
    {
        public int IdProduct { get; set; }
    }
}
