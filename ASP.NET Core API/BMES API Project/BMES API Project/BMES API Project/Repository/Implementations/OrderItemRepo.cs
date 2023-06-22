using BMES_API_Project.Database;
using BMES_API_Project.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class OrderItemRepo : iOrderItemRepo
    {
        private dbContext _dbContext;

        public OrderItemRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Remove(orderItem);
            _dbContext.SaveChanges();
        }

        public OrderItem FindOrderItemById(long id)
        {
            var orderItem = _dbContext.OrderItems.Find(id);
            return orderItem; 
        }

        public IEnumerable<OrderItem> FindOrderItemByOrderId(long id)
        {
            var orderItems = _dbContext.OrderItems.Where(o => o.OrderId == id);
            return orderItems; 
        }

        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            var orderItems = _dbContext.OrderItems;
            return orderItems; 
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges(); 
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            _dbContext.SaveChanges();
        }
    }
}
