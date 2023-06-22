using BMES_API_Project.Messages;
using BMES_API_Project.Messages.Request.Order;
using BMES_API_Project.Messages.Response.Order;
using BMES_API_Project.Repository;

namespace BMES_API_Project.Services.Implementations
{
    public class OrderService : iOrderService
    {
        private readonly iOrderRepo _orderRepo;
        private MessageMapper _messageMapper;

        public OrderService(iOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
            _messageMapper = new MessageMapper();
        }
        public GetOrderResponse GetOrder(GetOrderRequest getOrderRequest)
        {
            GetOrderResponse getOrderResponse = null; 
            if(getOrderRequest.Id > 0)
            {
                var order = _orderRepo.FindOrderById(getOrderRequest.Id);
                var orderDto = _messageMapper.MapToOrderDto(order);

                getOrderResponse = new GetOrderResponse
                {
                    Order = orderDto
                };
            }
            return getOrderResponse;
        }

        public FetchOrderResponse GetOrders(FetchOrdersRequest fetchOrdersRequest)
        {
            var orders = _orderRepo.GetAllOrders();
            var orderDtos = _messageMapper.MapToOrderDtos(orders);

            return new FetchOrderResponse
            {
                Orders = orderDtos
            }; 
        }
    }
}
