using Cats.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cats;

public sealed class CatsDbContext(DbContextOptions<CatsDbContext> options) : DbContext(options)
{
    public DbSet<Cat> Cats { get; set; } 
    public DbSet<Coat> Coats { get; set; } 
    public DbSet<Personality> Personalities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cat>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Cat>()
            .HasIndex(c => c.Name)
            .IsUnique();
        modelBuilder.Entity<Cat>()
            .HasMany(e => e.Coats)
            .WithMany(e => e.Cats)
            .UsingEntity("CatsCoats");
        modelBuilder.Entity<Cat>()
            .HasMany(e => e.Personalities)
            .WithMany(e => e.Cats)
            .UsingEntity("CatsPersonalities");
        
        modelBuilder.Entity<Coat>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Coat>()
            .HasIndex(c => c.Name)
            .IsUnique();
            
        modelBuilder.Entity<Personality>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Personality>()
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}
