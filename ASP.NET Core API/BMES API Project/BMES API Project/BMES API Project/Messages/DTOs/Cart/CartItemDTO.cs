using BMES_API_Project.Messages.DTOs.Product;

namespace BMES_API_Project.Messages.DTOs.Cart
{
    public class CartItemDTO
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
