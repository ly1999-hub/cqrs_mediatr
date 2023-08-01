using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateProductCommandHandler :IRequestHandler<CreateProductCommand,IActionResult>
    {
        public async Task<IActionResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            {
                product.Name = command.NameProduct;
                product.Price = command.PriceProduct;
                product.CreatedAt= DateTime.Now.ToUniversalTime();
                product.UpdatedAt= DateTime.Now.ToUniversalTime();
            }
            using (var _context=new ProductDBContext())
            {
                try
                {
                    _context.products.Add(product);
                    await _context.SaveChangesAsync();
                    return new ObjectResult(product.Id);
                }
                catch (Exception ex)
                {
                    LogInit.Init(2, ex.Message);
                    return new  StatusCodeResult(500);
                }
            }
        }
    }
}
