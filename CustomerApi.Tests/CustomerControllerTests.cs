using Moq;
using CustomerApi.Models;
using CustomerApi.Controllers;
using CustomerApi.Services;

namespace CustomerApi.Tests;

public class CustomerControllerTests
{
  private readonly Mock<ICustomerService> customerService;
  public CustomerControllerTests()
  {
    customerService = new Mock<ICustomerService>();
  }

  [Fact]
  public void GetCustomersList()
  {
    var customerList = GetCustomersData();
    customerService.Setup(x => x.GetCustomerList())
        .Returns(customerList);
    var customerController = new CustomersController(customerService.Object);

    var customerResult = customerController.GetCustomers();

    Assert.NotNull(customerResult);
    Assert.Equal(GetCustomersData().Count(), customerResult.Count());
    Assert.Equal(GetCustomersData().ToString(), customerResult.ToString());
    Assert.True(customerList.Equals(customerResult));
  }

  [Fact]
  public void GetCustomerById()
  {
    //arrange
    var customerList = GetCustomersData();
    customerService.Setup(x => x.GetCustomerById(2))
        .Returns(customerList[1]);
    var customerController = new CustomersController(customerService.Object);

    //act
    var productResult = customerController.GetCustomer(2);

    //assert
    Assert.NotNull(productResult);
    Assert.Equal(customerList[1].Id, productResult.Id);
    Assert.True(customerList[1].Id == productResult.Id);
  }

  [Fact]
  public void AddCustomer()
  {
    //arrange
    var customerList = GetCustomersData();
    customerService.Setup(x => x.AddCustomer(customerList[2]))
        .Returns(customerList[2]);
    var customerController = new CustomersController(customerService.Object);

    //act
    var productResult = customerController.PostCustomer(customerList[2]);

    //assert
    Assert.NotNull(productResult);
    Assert.Equal(customerList[2].Id, productResult.Id);
    Assert.True(customerList[2].Id == productResult.Id);
  }

  private List<Customer> GetCustomersData()
  {
    List<Customer> customersData = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Name 1",
                Email = "test@test.com"
            },
             new Customer
            {
                Id = 2,
                Name = "Name 2",
                Email = "test@test.com"
            },
            new Customer
            {
                Id = 3,
                Name = "Name 3",
                Email = "test@test.com"
            },

        };
    return customersData;
  }

}