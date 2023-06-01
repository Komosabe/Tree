using Microsoft.EntityFrameworkCore;
using Tree.Domain.Entities;

namespace Tree.Infrastructure.Persistence
{
    public class TreeDbContext : DbContext
    {
        public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options)
        {
        }
        public DbSet<Node> Nodes { get; set; }


        // When a Node (parent) is deleted, all its associated children (leaves) will also be automatically deleted.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(n => n.Children)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
