using BMES_API_Project.Messages.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.DTOs.Order
{
    public class OrderItemDTO
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId {get;set;}
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
