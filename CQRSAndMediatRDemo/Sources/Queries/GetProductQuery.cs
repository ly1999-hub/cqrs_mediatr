using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int IdProduct { get; set; }
    }
}
