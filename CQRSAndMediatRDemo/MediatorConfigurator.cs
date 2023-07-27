using CQRSAndMediatRDemo.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo
{
    public class MediatorConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatorConfigurator).Assembly);
        }
    }
}
