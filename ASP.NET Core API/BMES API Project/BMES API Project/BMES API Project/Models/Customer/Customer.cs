using BMES_API_Project.Models.Shared;
using System.Collections.Generic;


namespace BMES_API_Project.Models.Customer
{
    using Address;
    public class Customer:BaseObject
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<Order.Order> Orders { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
