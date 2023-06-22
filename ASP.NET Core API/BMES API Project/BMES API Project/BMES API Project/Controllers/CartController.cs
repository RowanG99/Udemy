using BMES_API_Project.Messages.Request.Cart;
using BMES_API_Project.Messages.Response.Cart;
using BMES_API_Project.Services;
using BMES_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly iCartSevice _cartService; 
        public CartController(iCartSevice cartSevice)
        {
            _cartService = cartSevice; 
        }

        [HttpGet]
        public ActionResult<FetchItemResponse> GetCart()
        {
            var fetchCartResponse = _cartService.FetchCart();
            return fetchCartResponse; 
        }

        [HttpPost]
        public ActionResult<AddItemToCartResponse> AddItemToCart(AddItemToCartRequest addItemToCartRequest)
        {
            var addItemToCartReponse =  _cartService.AddItemToCart(addItemToCartRequest);
            return addItemToCartReponse; 
        }

        [HttpDelete("{cartId}/{cartItemId}")]
        public ActionResult<RemoveItemFromCartResponse> RemoveItemFromCart(long id, long cartItemId)
        {
            var removeItemFromCartRequest = new RemoveItemFromCartRequest { CartId = id, CartItemId = cartItemId };
            var removeItemFromCartResponse = _cartService.RemoveItemFromCart(removeItemFromCartRequest);
            return removeItemFromCartResponse; 
        }
    }
}
