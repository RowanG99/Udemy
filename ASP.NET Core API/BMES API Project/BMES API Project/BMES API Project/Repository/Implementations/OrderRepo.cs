using BMES_API_Project.Database;
using BMES_API_Project.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class OrderRepo : iOrderRepo
    {
        private dbContext _dbContext; 

        public OrderRepo(dbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void DeleteOrder(Order order)
        {
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public Order FindOrderById(long id)
        {
            var order = _dbContext.Orders.Find(id);
            return order; 
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _dbContext.Orders;
            return orders; 
        }

        public void SaveOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
