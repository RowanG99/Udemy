using BMES_API_Project.Messages.Request.Cart;
using BMES_API_Project.Messages.Response.Cart;
using BMES_API_Project.Models.Cart;
using System.Collections.Generic;

namespace BMES_API_Project.Services
{
    public interface iCartSevice
    {
        AddItemToCartResponse AddItemToCart(AddItemToCartRequest addItemToCartRequest);
        RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest);
        string UniqueCartId();
        Cart GetCart();
        FetchItemResponse FetchCart();
        IEnumerable<CartItem> GetCartItem();
        int CartItemsCount();
        decimal GetCartTotal(); 
    }
}
