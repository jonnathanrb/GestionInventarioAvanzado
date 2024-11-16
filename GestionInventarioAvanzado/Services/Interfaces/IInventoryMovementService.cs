using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Services.Interfaces
{
    public interface IInventoryMovementService
    {
        GeneralResponse FindAll();
        GeneralResponse FindById(int id);
        GeneralResponse Add(CreateInventoryMovementDTO createInventoryMovementDTO);
        GeneralResponse Update(InventoryMovementDTO inventoryMovementDTO);
        GeneralResponse Delete(int id);
    }
}
