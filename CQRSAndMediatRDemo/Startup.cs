using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Sources.Commands;
using CQRSAndMediatRDemo.Sources.Queries;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                var dbContext = new ProductDBContext();
                dbContext.Database.EnsureCreated();
                LogInit.Init(4, "connected DB ....");

            }catch (Exception ex)
            {
                LogInit.Init(2, ex.Message);
            }
            MediatorConfigurator.Configure(services);
            services.AddSingleton<GetProductQueryHandler>();
            services.AddSingleton<CreateProductCommandHandler>();
        }
    }
}
