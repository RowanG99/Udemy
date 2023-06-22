using BMES_API_Project.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository
{
    public interface iCartRepo
    {
        public Cart FindCartById(long id);

        public IEnumerable<Cart> GetAllCarts();

        public void SaveCart(Cart cart);

        public void UpdateCart(Cart cart);
        public void DeleteCart(Cart cart);
    }
}
