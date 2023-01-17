using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Domain.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    
}