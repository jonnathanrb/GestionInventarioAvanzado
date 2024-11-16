using GestionInventarioAvanzado.Models;

namespace GestionInventarioAvanzado.Repositories.Interfaces
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> FindAll();
        Provider FindById(int id);
        bool Delete(Provider provider);
        Provider Add(Provider provider);
        Provider Update(Provider provider);
    }
}
