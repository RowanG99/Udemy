using BMES_API_Project.Database;
using BMES_API_Project.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class CartRepo :iCartRepo
    {
        private dbContext _dbContext; 

        public CartRepo(dbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public Cart FindCartById(long id)
        {
            var cart = _dbContext.Carts.Find(id);
            return cart; 
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            var carts = _dbContext.Carts;
            return carts; 
        }

        public void SaveCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
        }
        public void DeleteCart(Cart cart)
        {
            _dbContext.Carts.Remove(cart);
            _dbContext.SaveChanges();
        }
    }
}
