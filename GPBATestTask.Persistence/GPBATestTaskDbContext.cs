using GPBATestTask.Application.Interfaces;
using GPBATestTask.Domain.Entities;
using GPBATestTask.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GPBATestTask.Persistence;

public class GPBATestTaskDbContext : DbContext, IGPBATestTaskDbContext
{
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Provider> Providers { get; set; }

    public GPBATestTaskDbContext(DbContextOptions<GPBATestTaskDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OfferConfiguration());
        modelBuilder.ApplyConfiguration(new ProviderConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}