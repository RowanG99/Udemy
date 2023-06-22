using BMES_API_Project.Messages.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Cart
{
    public class AddItemToCartRequest
    {
        public long CartId { get; set; }
        public CartItemDTO CartItem { get; set; }
        public long ProductId { get; set; }
    }
}
 