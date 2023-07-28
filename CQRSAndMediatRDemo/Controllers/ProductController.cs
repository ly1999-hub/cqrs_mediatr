using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Sources.Commands;
using CQRSAndMediatRDemo.Sources.Queries;
using DocumentFormat.OpenXml.Office2016.Excel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
           var id= await _mediator.Send(command);
            if (id != null)
            {
                return new OkObjectResult(id);
            }
            return new ContentResult() { Content = "Lỗi máy chủ", StatusCode = 500 };
        }

        [HttpGet("{IdProduct:int?}")]
        public async Task<IActionResult> GetById(int IdProduct)
        {
            var query = new GetProductQuery();
            query.IdProduct=IdProduct;
            var product = await _mediator.Send(query);
            if(product != null)
            {
                return new OkObjectResult(product);
            }
            return new NotFoundResult();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var query= new GetProductsQuery();
            var products= await _mediator.Send(query);
            return new OkObjectResult(products);
        }
        [HttpGet("export-to-excel")] 
        public async Task<IActionResult> ExportToExcel()
        {
            var query=new GetProductsExportToExcelQuery();
            var fileContents= await _mediator.Send(query);
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            if (fileContents == null)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "List-Product.xlsx"
            );
        }
        
    }
}
