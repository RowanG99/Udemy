using BMES_API_Project.Database;
using BMES_API_Project.Models.Customer;
using System.Collections.Generic;

namespace BMES_API_Project.Repository.Implementations
{
    public class CustomerRepo : iCustomerRepo
    {
        private dbContext _dbContext; 

        public CustomerRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Remove(customer);
            _dbContext.SaveChanges();
        }

        public Customer FindCustomerById(long id)
        {
            var customer = _dbContext.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAAllCustomers()
        {
            var customers = _dbContext.Customers;
            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Update(customer);
            _dbContext.SaveChanges();
        }
    }
}
