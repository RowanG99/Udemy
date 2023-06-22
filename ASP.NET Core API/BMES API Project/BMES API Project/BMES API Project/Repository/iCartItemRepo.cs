using BMES_API_Project.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository
{
    public interface iCartItemRepo
    {
        public CartItem FindCartItemById(long id);

        public IEnumerable<CartItem> FindCartItemByCartId(long cartId);
        public void SaveCartItem(CartItem cartItem);

        public void UpdateCartItem(CartItem cartItem);

        public void DeleteCartItem(CartItem cartItem);
    }
}
