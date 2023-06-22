using BMES_API_Project.Messages.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Response.Order
{
    public class GetOrderResponse:ResponseBase
    {
        public OrderDTO Order { get; set; }
    }
}
