using CQRSAndMediatRDemo.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsExportToExcelHandler : IRequestHandler<GetProductsExportToExcelQuery, Byte[]>
    {
        public async Task<Byte[]> Handle(GetProductsExportToExcelQuery request, CancellationToken cancellationToken)
        {
            
            using (var context=new ProductDBContext())
            {
                var products = await context.products.ToListAsync(cancellationToken);
                byte[] fileContents;
                
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("ProductInfo");

                Sheet.Cells["A1"].Value = "Name";
                Sheet.Cells["B1"].Value = "Email";

                int row = 2;
                foreach (var product in products)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Value = product.Name;
                    Sheet.Cells[string.Format("B{0}", row)].Value = product.Price;
                    row++;
                }
                Sheet.Cells["A:AZ"].AutoFitColumns();
                fileContents = Ep.GetAsByteArray();
                return fileContents;
            }
        }
    }
}

