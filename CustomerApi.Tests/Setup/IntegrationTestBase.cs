using CustomerApi.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApi.Tests.Setup;

public class IntegrationTestBase : IClassFixture<IntegrationTestFactory<Program, CustomerContext>>
{
  public readonly IntegrationTestFactory<Program, CustomerContext> Factory;
  public readonly CustomerContext DbContext;

  public IntegrationTestBase(IntegrationTestFactory<Program, CustomerContext> factory)
  {
    Factory = factory;
    var scope = factory.Services.CreateScope();
    DbContext = scope.ServiceProvider.GetRequiredService<CustomerContext>();
  }
}
