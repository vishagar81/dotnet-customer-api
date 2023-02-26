using CustomerApi.Data;
using CustomerApi.Models;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _dbContext;

        public CustomerService(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetCustomerList()
        {
            return _dbContext.Customers.ToList();
        }
        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public Customer AddCustomer(Customer Customer)
        {
            var result = _dbContext.Customers.Add(Customer);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Customer UpdateCustomer(Customer Customer)
        {
            var result = _dbContext.Customers.Update(Customer);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteCustomer(int Id)
        {
            var filteredData = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}