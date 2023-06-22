using BMES_API_Project.Messages.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Response.Order
{
    public class FetchOrderResponse:ResponseBase
    {
        public int OrdersPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
