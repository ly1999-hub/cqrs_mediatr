using MediatR;

namespace CQRSAndMediatRDemo.Sources.Commands
{
    public class CreateProductCommand : IRequest<int?>
    {
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
    }
}
