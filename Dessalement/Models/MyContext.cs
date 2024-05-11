using Microsoft.EntityFrameworkCore;
namespace Dessalement.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet <Usager> usagers { get; set; }
        public DbSet<Parcelle> parcelles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usager>()
                .HasKey(u => new { u.typeusage, u.codeusage });
            modelBuilder.Entity<Parcelle>()
                .HasAlternateKey(p => p.UsagerId);
        }
    }
}
