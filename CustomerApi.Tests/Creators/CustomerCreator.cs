using CustomerApi.Data;
using CustomerApi.Models;

namespace CustomerApi.Tests.Creators;

public class CustomerCreator
{
   private readonly CustomerContext _customerContext;

        public CustomerCreator(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task AddCustomersAsync()
        {
            var customers = new List<Customer>
            {
                new Customer{ Id = 1, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 2, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 3, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 4, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 5, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 6, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 7, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 8, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 9, Email = "test@test.com", Name = "Customer1"},
                new Customer{ Id = 10, Email = "test@test.com", Name = "Customer1"},
            };

            await _customerContext.AddRangeAsync(customers);
            await _customerContext.SaveChangesAsync();
        }

        public async Task<int> AddCustomerAsync()
        {
            var customer = new Customer{ Id = 1, Email = "test@test.com", Name = "Customer1"};

            await _customerContext.AddAsync(customer);
            await _customerContext.SaveChangesAsync();

            return customer.Id;
        }
}
