using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateProductCommandHandler :IRequestHandler<CreateProductCommand,int?>
    {
        public async Task<int?> Handle(CreateProductCommand command, CancellationToken cancellationToken)
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
                    return product.Id;
                }
                catch (Exception ex)
                {
                    LogInit.Init(2, ex.Message);
                    return null;
                }
            }
        }
    }
}
