using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class UpdateProductCommand : IRequest<IActionResult>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
    }
}
