using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.BLL.IManager.Common;
using OrderManagement.BLL.Manager.Common;
using OrderManagement.DAL.ApplicationDbContext;

namespace OrderManagement.IOC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            //services.AddScoped<IOrderDbContext>(provider =>provider.GetService<OrderDbContext>());

            services.AddScoped<IQueryDataDictionaryManager, QueryDataDictionaryManager>();

            return services;
        }
    }
}
