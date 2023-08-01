using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateProductCommand : IRequest<IActionResult>
    {
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
    }
}
