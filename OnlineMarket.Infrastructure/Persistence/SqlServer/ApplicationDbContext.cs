using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Infrastructure.Persistence.SqlServer;

public class ApplicationDbContext : DbContext ,IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}