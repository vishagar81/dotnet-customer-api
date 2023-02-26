using CustomerApi.Data;
using CustomerApi.Tests.Creators;
using CustomerApi.Tests.Setup;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApiIntegrationTests;

public class CustomerApiIntegrationTests: IntegrationTestBase
{
  private readonly IntegrationTestFactory<Program, CustomerContext> _factory;
  private readonly CustomerCreator _customerCreator;

  public CustomerApiIntegrationTests(IntegrationTestFactory<Program, CustomerContext> factory) : base(factory)
  {
      _factory = factory;
      var scope = factory.Services.CreateScope();
      _customerCreator = scope.ServiceProvider.GetRequiredService<CustomerCreator>();
  }

  [Fact]
  public async Task Test_Get_All_WithoutKey_Should_Return_UnAuthorized()
  {
    await _customerCreator.AddCustomersAsync();

    var client = _factory.CreateClient();

    var response = await client.GetAsync("/api/Customers");

    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Unauthorized);     
  }


  [Fact]
  public async Task Test_Get_All_WithKey_Should_Return_OK()
  {
    await _customerCreator.AddCustomersAsync();
    var client = _factory.CreateClient();

    client.DefaultRequestHeaders.Add("X-API-KEY", "76d70b61-a2f5-45ce-994b-bb7db9898454");

    var response = await client.GetAsync("/api/Customers");

    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);     
  }

  
}
