using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IActionResult>
    {

        public async Task<IActionResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            using (var _context = new ProductDBContext())
            {
                var product = await _context.products.FindAsync(query.IdProduct);
                if (product != null) 
                    return new OkObjectResult(product);
                return new NotFoundResult();
            }
        }
    }
}
