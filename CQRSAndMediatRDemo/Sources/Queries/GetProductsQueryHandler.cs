using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery,List<Product>>
    {
        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            using (var context = new ProductDBContext())
            {
                var products = await context.products.ToListAsync();
                return products;
            }
        }
    }
}
