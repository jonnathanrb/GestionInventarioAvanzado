using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> FindAll();
        ProductCategory FindById(int id);
        bool Delete(ProductCategory productCategory);
        ProductCategory Add(ProductCategory productCategory);
        ProductCategory Update(ProductCategory productCategory);
    }
}
