using GestionInventarioAvanzado.Data;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestionInventarioAvanzado.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProviderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Provider Add(Provider provider)
        {
            provider.CreatedAt = DateTime.Now;
            var productCategorySaved = _dbContext.Add(provider);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }

        public bool Delete(Provider provider)
        {
            EntityEntry entity = _dbContext.Remove(provider);
            _dbContext.SaveChanges();

            return entity != null;
        }

        public IEnumerable<Provider> FindAll()
        {
            return _dbContext.Providers.ToList();
        }

        public Provider FindById(int id)
        {
            return _dbContext.Providers.FirstOrDefault(x => x.Id == id);
        }

        public Provider Update(Provider provider)
        {
            provider.UpdatedAt = DateTime.Now;
            var productCategorySaved = _dbContext.Update(provider);
            _dbContext.SaveChanges();

            return productCategorySaved.Entity;
        }
    }
}
