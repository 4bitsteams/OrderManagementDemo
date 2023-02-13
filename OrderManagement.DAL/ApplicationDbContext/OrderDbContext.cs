using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity.Models;

namespace OrderManagement.DAL.ApplicationDbContext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {

        }
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            using var tran = await base.Database.BeginTransactionAsync();
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);
                await tran.CommitAsync();
                var d = tran.TransactionId;
                return result;
            }
            catch (Exception)
            {
                await tran.RollbackAsync();
                throw;
            }

        }

        public DbSet<Order> Orders { get; set; }
    }
}
