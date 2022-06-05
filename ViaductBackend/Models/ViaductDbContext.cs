using Microsoft.EntityFrameworkCore;

namespace ViaductBackend.Models
{
    public class ViaductDbContext : DbContext
    {
        public ViaductDbContext(DbContextOptions<ViaductDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
