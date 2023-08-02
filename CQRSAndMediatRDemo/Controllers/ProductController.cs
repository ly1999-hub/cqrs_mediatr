using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Sources.Commands;
using CQRSAndMediatRDemo.Sources.Queries;
using DocumentFormat.OpenXml.Office2016.Excel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers
{
    [ApiController]
    [Route("api/v1/product/[controller]")]
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
            return await _mediator.Send(command);
        }

        [HttpGet("{IdProduct:int?}")]
        public async Task<IActionResult> GetById(int IdProduct)
        {
            var query = new GetProductQuery();
            query.IdProduct = IdProduct;
            return await _mediator.Send(query);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var query = new GetProductsQuery();
            return await _mediator.Send(query);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("export-to-excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var query = new GetProductsExportToExcelQuery();
            var fileContents = await _mediator.Send(query);
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
        [HttpDelete("{IdProduct:int?}")]
        public async Task<IActionResult> Delete(int IdProduct)
        {
            var command=new DeleteProductCommand();
            command.IdProduct = IdProduct;
            return await _mediator.Send(command);
        }
        
    }
}
