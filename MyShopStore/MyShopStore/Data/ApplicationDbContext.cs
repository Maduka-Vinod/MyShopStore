using Microsoft.EntityFrameworkCore;
using MyShopStore.Models;

namespace MyShopStore.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
