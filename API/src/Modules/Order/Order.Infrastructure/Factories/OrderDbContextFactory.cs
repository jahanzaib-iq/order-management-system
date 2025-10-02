

namespace Order.Infrastructure.Factories;

public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
{
  public OrderDbContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

    var builder = new DbContextOptionsBuilder<OrderDbContext>();
    var connectionString = configuration.GetConnectionString("orderConnectionString");

    builder.UseSqlServer(connectionString);

    return new OrderDbContext(builder.Options);
  }
}
