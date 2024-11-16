using GestionInventarioAvanzado.Data;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionInventarioAvanzado.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            var productCategorySaved = _dbContext.Add(productCategory);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }

        public bool Delete(ProductCategory productCategory)
        {
            EntityEntry entity = _dbContext.Remove(productCategory);
            _dbContext.SaveChanges();

            return entity != null;
        }

        public IEnumerable<ProductCategory> FindAll()
        {
            return _dbContext.ProductCategories.ToList();
        }

        public ProductCategory FindById(int id)
        {
            return _dbContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public ProductCategory Update(ProductCategory productCategory)
        {
            var productCategorySaved = _dbContext.Update(productCategory);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }
    }
}
