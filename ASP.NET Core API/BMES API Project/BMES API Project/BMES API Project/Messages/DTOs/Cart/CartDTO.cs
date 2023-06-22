using System;
using System.Collections.Generic;

namespace BMES_API_Project.Messages.DTOs.Cart
{
    public class CartDTO
    {
        public CartDTO()
        {
            CartItems = new List<CartItemDTO>(); 
        }

        public long Id { get; set; }
        public string UniqueCartId { get; set; }
        public int CartStatues { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool isDeleted { get; set; }
        public IEnumerable<CartItemDTO> CartItems { get; set; }
    }
}
