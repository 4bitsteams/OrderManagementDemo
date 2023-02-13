using Microsoft.EntityFrameworkCore;
using OrderManagement.Entity.Models;

namespace OrderManagement.DAL.ApplicationDbContext
{
    public interface IOrderDbContext 
    {
        DbSet<Order> Orders { get; set; }
    }
}
