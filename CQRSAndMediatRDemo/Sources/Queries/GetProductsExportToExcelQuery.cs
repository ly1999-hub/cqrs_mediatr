using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsExportToExcelQuery : IRequest<Byte[]>
    {
        

    }
}
