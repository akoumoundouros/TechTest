using Microsoft.EntityFrameworkCore;

namespace TechTest.Data
{
    public class TTContext : DbContext
    {
        public TTContext(DbContextOptions<TTContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
