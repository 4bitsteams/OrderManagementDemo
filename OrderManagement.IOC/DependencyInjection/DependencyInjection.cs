using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.BLL.IManager;
using OrderManagement.BLL.Manager;
using OrderManagement.DAL.ApplicationDbContext;
using OrderManagement.DAL.IRepository;
using OrderManagement.DAL.Repository;
using OrderManagement.Mapping;

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

            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IMapper, Mapper>();
            //services.AddScoped<ICacheManager, CacheManager>();

            services.AddAutoMapper(c => c.AddProfile<SetupMapperProfile>(), typeof(SetupMapperProfile));
            return services;
        }
    }
}
