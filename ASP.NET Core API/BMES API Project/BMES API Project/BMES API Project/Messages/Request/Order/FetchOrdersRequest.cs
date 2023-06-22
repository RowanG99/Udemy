using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Order
{
    public class FetchOrdersRequest
    {
        public int PageNumber { get; set; }
        public int OrdersPerPage { get; set; }
    }
}
