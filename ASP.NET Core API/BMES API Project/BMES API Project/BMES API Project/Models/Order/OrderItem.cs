using BMES_API_Project.Models.Shared;

namespace BMES_API_Project.Models.Order
{
    public class OrderItem:BaseObject
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
