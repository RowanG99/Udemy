using BMES_API_Project.Database;
using BMES_API_Project.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class ProductRepo : iProductRepo
    {
        private dbContext _dbContext; 

        public ProductRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product FindProductById(long id)
        {
            var product = _dbContext.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand);
            return products;
        }

        public void SaveProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
