using CQRSAndMediatRDemo.Data;
using DocumentFormat.OpenXml.InkML;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,IActionResult>
    {
        public async Task<IActionResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            
            using ( var context =new ProductDBContext())
            {
                try
                {
                    var product = await context.products.FindAsync(command.IdProduct);
                    if(product == null)
                    {
                        return new NotFoundResult();
                    }
                    context.products.Remove(product);
                    await context.SaveChangesAsync();
                    return new NoContentResult();
                }
                catch (Exception ex)
                {
                    LogInit.Init(2, ex.Message);
                    return new NotFoundResult();
                }
            }    
        }
    }
}
