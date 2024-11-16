using GestionInventarioAvanzado.Models;

namespace GestionInventarioAvanzado.Repositories.Interfaces
{
    public interface IInventoryMovementRepository
    {
        IEnumerable<InventoryMovement> FindAll();
        InventoryMovement FindById(int id);
        bool Delete(InventoryMovement order);
        InventoryMovement Add(InventoryMovement order);
        InventoryMovement Update(InventoryMovement order);
    }
}
