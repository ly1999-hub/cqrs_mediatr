using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class DeleteProductCommand : IRequest<IActionResult>
    {
        public int IdProduct { get; set; }
    }
}
