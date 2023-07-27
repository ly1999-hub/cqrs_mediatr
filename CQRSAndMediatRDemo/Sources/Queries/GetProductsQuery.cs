using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
    }
}
