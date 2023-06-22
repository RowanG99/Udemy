using BMES_API_Project.Messages.Request.Order;
using BMES_API_Project.Messages.Response.Order;
using BMES_API_Project.Services;
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
    public class OrderController : ControllerBase
    {
        private readonly iOrderService _orderService;

        public OrderController(iOrderService orderService)
        {
            _orderService = orderService; 
        }

        [HttpGet(template:"{id}")]
        public ActionResult<GetOrderResponse>GetOrder(long id)
        {
            var getOrderRequest = new GetOrderRequest
            {
                Id = id
            };
            var getOrderResponse = _orderService.GetOrder(getOrderRequest);
            return getOrderResponse; 
        }

        [HttpGet(template:"")]
        public ActionResult<FetchOrderResponse> GetOrders()
        {
            var fetchOrdersRequest = new FetchOrdersRequest { };
            var fetchOrdersResponse = _orderService.GetOrders(fetchOrdersRequest);
            return fetchOrdersResponse;
        }
    }
}
