using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models;
using CustomerApi.Services;
using CustomerApi.Filters;

namespace CustomerApi.Controllers
{
  [Route("api/[controller]")]
  [ApiKey]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    // GET: api/Customers
    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
      var customerList = _customerService.GetCustomerList();      
      return customerList;
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public Customer GetCustomer(int id)
    {
      var customer = _customerService.GetCustomerById(id);

      return customer;
    }

    // PUT: api/Customers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public Customer PutCustomer(Customer customer)
    {
      return _customerService.UpdateCustomer(customer);
    }

    // POST: api/Customers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public Customer PostCustomer(Customer customer)
    {
      return _customerService.AddCustomer(customer);
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public bool DeleteCustomer(int id)
    {
      return _customerService.DeleteCustomer(id);
    }
  }
}
