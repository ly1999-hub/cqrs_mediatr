using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using System.Threading;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {

        public async Task<Product?> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            using (var _context = new ProductDBContext())
            {
                var product = await _context.products.FindAsync(query.IdProduct);
                if (product != null)
                {
                    return product;
                }
                return null;
            }
        }
    }
}
