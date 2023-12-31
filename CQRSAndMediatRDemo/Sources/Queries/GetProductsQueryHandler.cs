﻿using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Sources.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery,IActionResult>
    {
        public async Task<IActionResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            using (var context = new ProductDBContext())
            {
                try
                {
                    var products = await context.products.ToListAsync();
                    if (products != null)
                    {
                        return new OkObjectResult(products);
                    }
                    return new NotFoundResult();
                }
                catch(Exception ex)
                {
                    LogInit.Init(2, ex.Message);
                    return new BadRequestObjectResult(ex);
                }
            }
        }
    }
}
