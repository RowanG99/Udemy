using BMES_API_Project.Messages.Request.Order;
using BMES_API_Project.Messages.Response.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Services
{
    public interface iOrderService
    {
        GetOrderResponse GetOrder(GetOrderRequest getOrderRequest);
        FetchOrderResponse GetOrders(FetchOrdersRequest fetchOrdersRequest);
    }
}
