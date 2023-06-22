using BMES_API_Project.Database;
using BMES_API_Project.Models.Cart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class CartItemRepo : iCartItemRepo
    {
        private dbContext _dbContext;

        public CartItemRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CartItem FindCartItemById(long id)
        {
            var cartItem = _dbContext.CartItems.Find(id);
            return cartItem;
        }

        public IEnumerable<CartItem> FindCartItemByCartId(long cartId)
        {
            var cartItem = _dbContext.CartItems.Where(cartItem => cartItem.CartId == cartId).Include(navigationPropertyPath: c => c.Product);
            return cartItem;
        }
        public void SaveCartItem(CartItem cartItem)
        {
            _dbContext.CartItems.Add(cartItem);
            _dbContext.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _dbContext.CartItems.Update(cartItem);
            _dbContext.SaveChanges(); 
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _dbContext.CartItems.Remove(cartItem);
            _dbContext.SaveChanges();
        }
    }
}
