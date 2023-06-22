using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Cart
{
    public class RemoveItemFromCartRequest
    {
        public long CartId { get; set; }
        public long CartItemId { get; set; }
    }
}
