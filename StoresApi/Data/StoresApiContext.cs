using Microsoft.EntityFrameworkCore;
using StoresApi.Models;

namespace StoresApi.Data
{
    public class StoresApiContext : DbContext
    {
        public StoresApiContext(DbContextOptions<StoresApiContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
