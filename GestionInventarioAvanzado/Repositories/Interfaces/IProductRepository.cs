using GestionInventarioAvanzado.Models;

namespace GestionInventarioAvanzado.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindAll();
        Product FindById(int id);
        bool Delete(Product product);
        Product Add(Product product);
        Product Update(Product product);
    }
}
