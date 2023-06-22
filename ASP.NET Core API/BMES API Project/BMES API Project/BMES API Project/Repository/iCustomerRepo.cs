using BMES_API_Project.Models.Customer;
using System.Collections.Generic;

namespace BMES_API_Project.Repository
{
    public interface iCustomerRepo
    {
        Customer FindCustomerById(long id);
        IEnumerable<Customer> GetAAllCustomers();
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
