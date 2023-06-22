using BMES_API_Project.Database;
using BMES_API_Project.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Repository.Implementations
{
    public class CategoryRepo : iCategoryRepo
    {
        private dbContext _dbContext;

        public CategoryRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCategory(Category category)
        {
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }

        public Category FindCategoryById(long id)
        {
            var category = _dbContext.Categories.Find(id);
            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _dbContext.Categories;
            return categories;
        }

        public void SaveCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }
    }
}
