using BMES_API_Project.Database;
using BMES_API_Project.Models.Product;
using System.Collections.Generic;

namespace BMES_API_Project.Repository.Implementations
{
    public class BrandRepo : iBrandRepo
    {
        private dbContext _dbContext; 

        public BrandRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBrand(Brand brand)
        {
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
        }

        public Brand FindBrandById(long id)
        {
            var brand = _dbContext.Brands.Find(id);
            return brand;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            var brands = _dbContext.Brands;
            return brands;
        }

        public void SaveBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            _dbContext.Brands.Update(brand);
            _dbContext.SaveChanges();
        }
    }
}
