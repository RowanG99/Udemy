using BMES_API_Project.Messages;
using BMES_API_Project.Messages.Request.Cart;
using BMES_API_Project.Messages.Response.Cart;
using BMES_API_Project.Models.Cart;
using BMES_API_Project.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BMES_API_Project.Services.Implementations
{
    public class CartService : iCartSevice
    {
        private const string UniqueCartIdSessionKey = "UniqueCartId";
        private readonly iCartRepo _cartRepo;
        private readonly iCartItemRepo _cartItemRepo;
        private MessageMapper _messageMapper;
        private readonly HttpContext _httpContext;
        private readonly iProductRepo _productRepo;

        public CartService(IHttpContextAccessor httpContextAccessor, iCartItemRepo cartItemRepo, iCartRepo cartRepo, iProductRepo productRepo)
        {
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
            _messageMapper = new MessageMapper();
            _httpContext = httpContextAccessor.HttpContext;
            _productRepo = productRepo;
        }

        public AddItemToCartResponse AddItemToCart(AddItemToCartRequest addItemToCartRequest)
        {
            AddItemToCartResponse response = new AddItemToCartResponse();

            var cart = GetCart();

            if (cart != null)
            {
                var existingCartItem = _cartItemRepo.FindCartItemByCartId(cart.Id).FirstOrDefault(c => c.ProductId == addItemToCartRequest.ProductId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _cartItemRepo.UpdateCartItem(existingCartItem);
                    response.CartItem = _messageMapper.MaptoCartItemDto(existingCartItem);
                }
                else
                {
                    var product = _productRepo.FindProductById(addItemToCartRequest.ProductId);
                    if (product != null)
                    {
                        var cartItem = new CartItem
                        {
                            CartId = cart.Id,
                            cart = cart,
                            ProductId = addItemToCartRequest.ProductId,
                            Product = product,
                            Quantity = 1
                        };
                        _cartItemRepo.SaveCartItem(cartItem);
                        response.CartItem = _messageMapper.MaptoCartItemDto(cartItem);
                    }
                }
            }
            else
            {
                var product = _productRepo.FindProductById(addItemToCartRequest.ProductId);
                if (product != null)
                {
                    var newCart = new Cart
                    {
                        UniqueCartId = UniqueCartId(),
                        CartStatus = CartStatus.Open
                    };

                    _cartRepo.SaveCart(newCart);

                    var cartItem = new CartItem
                    {
                        CartId = newCart.Id,
                        cart = newCart,
                        ProductId = addItemToCartRequest.ProductId,
                        Product = product,
                        Quantity = 1
                    };

                    _cartItemRepo.SaveCartItem(cartItem);
                    response.CartItem = _messageMapper.MaptoCartItemDto(cartItem); 
                }
            }
            return response;
        }

            public RemoveItemFromCartResponse RemoveItemFromCart(RemoveItemFromCartRequest removeItemFromCartRequest)
            {
            RemoveItemFromCartResponse response = new RemoveItemFromCartResponse();
            var cartItem = _cartItemRepo.FindCartItemById(removeItemFromCartRequest.CartItemId);
            _cartItemRepo.DeleteCartItem(cartItem);

            response.CartItemId = cartItem.Id;
            return response;
        }

            public string UniqueCartId()
            {
                if (!string.IsNullOrWhiteSpace(_httpContext.Session.GetString(UniqueCartIdSessionKey)))
                {
                    return _httpContext.Session.GetString(UniqueCartIdSessionKey);
                }
                else
                {
                    var uniqueId = Guid.NewGuid().ToString();
                    _httpContext.Session.SetString(UniqueCartIdSessionKey, uniqueId);

                    return _httpContext.Session.GetString(UniqueCartIdSessionKey);
                }
            }

            public Cart GetCart()
            {
            var uniqueId = UniqueCartId();
            var cart = _cartRepo.GetAllCarts().FirstOrDefault(c => c.UniqueCartId == uniqueId);
            return cart;
            }

            public FetchItemResponse FetchCart()
            {
            FetchItemResponse response = new FetchItemResponse();
            var cart = GetCart();
            IList<CartItem> cartItems = new List<CartItem>();

            if (cart != null)
            {
                cartItems = _cartItemRepo.FindCartItemByCartId(cart.Id).ToArray();
                var cartItemsDto = _messageMapper.MaptoCartItemDto(cartItems);
                var cartDto = _messageMapper.MaptoCartDto(cart);
                cartDto.CartItems = cartItemsDto;
                response.Cart = cartDto;
            }

            return response;
        }

            public IEnumerable<CartItem> GetCartItem()
            {
            IList<CartItem> cartItems = new List<CartItem>();

            var cart = GetCart();

            if (cart != null)
            {
                cartItems = _cartItemRepo.FindCartItemByCartId(cart.Id).ToArray();
            }

            return cartItems;
        }

            public int CartItemsCount()
            {
            var count = 0;
            var cartItems = GetCartItem();

            foreach (var cartItem in cartItems)
            {
                count += cartItem.Quantity;
            }

            return count;
        }

            public decimal GetCartTotal()
            {
            decimal total = 0;

            var cartItems = GetCartItem();

            foreach (var cartItem in cartItems)
            {
                var product = _productRepo.FindProductById(cartItem.ProductId);
                total = total + (cartItem.Quantity * product.Price);
            }

            return total;
        }
    }
}
