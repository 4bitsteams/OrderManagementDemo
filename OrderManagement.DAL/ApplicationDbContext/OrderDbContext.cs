using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity.Models;

namespace OrderManagement.DAL.ApplicationDbContext
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
