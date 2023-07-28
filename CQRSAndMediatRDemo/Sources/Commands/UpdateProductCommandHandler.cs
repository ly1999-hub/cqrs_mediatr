using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IActionResult>
    {
        public async Task<IActionResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
           using( var context=new ProductDBContext())
            {
                var product = await context.products.FindAsync(command.ProductId);
                if (product != null)
                {
                    product.Name= command.Name;
                    product.Price= command.Price;
                    product.UpdatedAt=DateTime.Now.ToUniversalTime();
                    context.Update(product);
                    context.SaveChanges();
                    return new OkObjectResult(product);
                }
                return new NotFoundResult();
            }
        }
    }
}
