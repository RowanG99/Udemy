using BMES_API_Project.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository
{
    public interface iOrderItemRepo
    {
        OrderItem FindOrderItemById(long id);
        IEnumerable<OrderItem> FindOrderItemByOrderId(long id);
        IEnumerable<OrderItem> GetAllOrderItems();
        void SaveOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(OrderItem orderItem); 
    }
}
