using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class APIDbContext : DbContext
    {
        
       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Ticket>()
        .Property(t => t.Id)
        .ValueGeneratedOnAdd();  // Set it to auto-increment
}

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
