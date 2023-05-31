using Microsoft.EntityFrameworkCore;
using Tree.Models;

namespace Tree.Data
{
    public class TreeDbContext : DbContext
    {
        public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options)
        {
        }
        public DbSet<Node> Nodes { get; set; }


        // When a Node (parent) is deleted, all its associated leaves (children) will also be automatically deleted.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasMany(n => n.Children)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("TreeDb");
            }
        }
    }
}
