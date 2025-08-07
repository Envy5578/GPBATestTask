using GPBATestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPBATestTask.Application.Interfaces;

public interface IGPBATestTaskDbContext
{
    DbSet<Offer> Offers { get; set; }
    DbSet<Provider> Providers { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}