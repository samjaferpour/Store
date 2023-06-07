using Microsoft.EntityFrameworkCore;

namespace StoreBE.Entities
{
    public class StoreBeDbContext : DbContext
    {
        public StoreBeDbContext(DbContextOptions<StoreBeDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
