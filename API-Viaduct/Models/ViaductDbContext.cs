namespace API_Viaduct.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ViaductDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ViaductDbContext(DbContextOptions<ViaductDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
