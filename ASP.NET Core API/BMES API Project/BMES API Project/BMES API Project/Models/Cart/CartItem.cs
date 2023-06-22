namespace BMES_API_Project.Models.Cart
{
    using Shared;
    using Product;

    public class CartItem:BaseObject
    {
        public long CartId { get; set; }
        public Cart cart { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
