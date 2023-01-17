using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Interfaces;
using OnlineMarket.Infrastructure.Persistence.SqlServer;

namespace OnlineMarket.DomainTest.Persistence;

public class DomainDatabaseFixture : IDisposable
{
    private readonly string _connectionString = "Server=192.168.223.16; Database=OnlineMarketTest;User Id=sa; password=symbian; Trusted_Connection=false; MultipleActiveResultSets=true;";
    public IApplicationDbContext Context { get;private set; }
    
    public DomainDatabaseFixture()
    {
       var dbOption = new DbContextOptionsBuilder<ApplicationDbContext>();
      var optionsBuilder= dbOption.UseSqlServer(_connectionString);
      
      Context = new ApplicationDbContext(optionsBuilder.Options);
      
      Context.Database.EnsureCreated();

    }
    
    public void Dispose()
    {
        Context.Database.EnsureDeleted();
    }
    
    
}