using GestionInventarioAvanzado.Data;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionInventarioAvanzado.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product product)
        {
            product.CreatedAt = DateTime.Now;
            var productCategorySaved = _dbContext.Add(product);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }

        public bool Delete(Product product)
        {
            EntityEntry entity = _dbContext.Remove(product);
            _dbContext.SaveChanges();

            return entity != null;
        }

        public IEnumerable<Product> FindAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product FindById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product Update(Product product)
        {
            product.UpdatedAt = DateTime.Now;
            var productCategorySaved = _dbContext.Update(product);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }
    }
}
