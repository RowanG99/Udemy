using BMES_API_Project.Models.Shared;
using System.Collections.Generic;

namespace BMES_API_Project.Models.Order
{
    public class Order : BaseObject
    {
        public decimal OrderTotal { get; set; }
        public decimal OrderItemTotal { get; set; }
        public decimal ShippingCharge { get; set; }
        public long CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        public OrderStatus OrderStatus  { get; set; }
        public long AddressId { get; set; }
        public Address.Address DeliveryAddress { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
