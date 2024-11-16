using GestionInventarioAvanzado.Models;

namespace GestionInventarioAvanzado.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> FindAll();
        Order FindById(int id);
        bool Delete(Order order);
        Order Add(Order order);
        Order Update(Order order);
    }
}
