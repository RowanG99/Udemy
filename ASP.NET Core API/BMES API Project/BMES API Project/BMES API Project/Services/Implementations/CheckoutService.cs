using BMES_API_Project.Messages;
using BMES_API_Project.Messages.Request.Checkout;
using BMES_API_Project.Messages.Response.Checkout;
using BMES_API_Project.Models.Order;
using BMES_API_Project.Repository;
using System.Net;

namespace BMES_API_Project.Services.Implementations
{
    public class CheckoutService:iCheckoutService
    {
        private readonly iOrderRepo _orderRepository;
        private MessageMapper _messageMapper;
        private iCustomerRepo _customerRepository;
        private iPersonRepo _personRepository;
        private iAddressRepo _addressRepository;
        private iOrderItemRepo _orderItemRepository;
        private iCartRepo _cartRepository;
        private iCartItemRepo _cartItemRepository;
        private iCartSevice _cartService;

        public CheckoutService(
            iCustomerRepo customerRepository,
            iPersonRepo personRepository,
            iAddressRepo addressRepository,
            iOrderRepo orderRepository,
            iOrderItemRepo orderItemRepository,
            iCartRepo cartRepository,
            iCartItemRepo cartItemRepository,
            iCartSevice cartService
        )
        {
            _orderRepository = orderRepository;
            _messageMapper = new MessageMapper();
            _customerRepository = customerRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _cartService = cartService;
        }

        public CheckOutResponse ProcessCheckout(CheckOutRequest checkoutRequest)
        {
            CheckOutResponse response = new CheckOutResponse();
            var customer = _messageMapper.MapToCustomer(checkoutRequest.Customer);

            var person = customer.Person;

            _personRepository.SavePerson(person);

            var address = _messageMapper.MaptoAddress(checkoutRequest.Address);

            _addressRepository.SaveAddress(address);

            customer.PersonId = person.Id;
            customer.Person = person;

            _customerRepository.SaveCustomer(customer);

            var cart = _cartService.GetCart();

            if (cart != null)
            {
                var cartItems = _cartItemRepository.FindCartItemByCartId(cart.Id);
                var cartTotal = _cartService.GetCartTotal();
                decimal shippingCharge = 0;
                var orderTotal = cartTotal + shippingCharge;

                var order = new Order
                {
                    OrderTotal = orderTotal,
                    OrderItemTotal = cartTotal,
                    ShippingCharge = shippingCharge,
                    AddressId = address.Id,
                    DeliveryAddress = address,
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderStatus = OrderStatus.Submitted
                };

                _orderRepository.SaveOrder(order);

                foreach (var cartItem in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        Quantity = cartItem.Quantity,
                        Order = order,
                        OrderId = order.Id,
                        Product = cartItem.Product,
                        ProductId = cartItem.ProductId
                    };

                    _orderItemRepository.SaveOrderItem(orderItem);
                }

                _cartRepository.DeleteCart(cart);

                response.StatusCode = HttpStatusCode.Created;
                response.Messages.Add("Order created");
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Messages.Add("There is a problem creating the order");
            }

            return response;
        }
    }
}
