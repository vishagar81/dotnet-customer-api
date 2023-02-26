using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
  public class CustomerContext : DbContext
  {
    protected readonly IConfiguration _configuration;
    public CustomerContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("Default"));
    }

    public DbSet<Customer> Customers { get; set; } = null!;
  }
}