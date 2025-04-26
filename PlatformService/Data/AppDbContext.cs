namespace PlatformService.Data;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;   
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Platform> Platforms { get; set; } = null!;
    public DbSet<Command> Commands { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Platform>().HasKey(p => p.Id);
        modelBuilder.Entity<Command>().HasKey(c => c.Id);
        modelBuilder.Entity<Platform>().HasMany(p => p.Commands).WithOne(c => c.Platform).HasForeignKey(c => c.PlatformId);
    }
}