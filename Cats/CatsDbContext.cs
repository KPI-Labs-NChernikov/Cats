using Cats.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cats;

public sealed class CatsDbContext(DbContextOptions<CatsDbContext> options) : DbContext(options)
{
    public DbSet<Breed> Breeds { get; set; } 
    public DbSet<Coat> Coats { get; set; } 
    public DbSet<Personality> Personalities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Breed>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Breed>()
            .HasIndex(c => c.Name)
            .IsUnique();
        modelBuilder.Entity<Breed>()
            .HasMany(e => e.Coats)
            .WithMany(e => e.Breeds)
            .UsingEntity("BreedsCoats");
        modelBuilder.Entity<Breed>()
            .HasMany(e => e.Personalities)
            .WithMany(e => e.Breeds)
            .UsingEntity("BreedsPersonalities");
        modelBuilder.Entity<Breed>()
            .Property(c => c.ImagePath)
            .HasMaxLength(255);
        
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
