using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Services.Interfaces
{
    public interface IOrderService
    {
        GeneralResponse FindAll();
        GeneralResponse FindById(int id);
        GeneralResponse Add(CreateOrderDTO createOrderDTO);
        GeneralResponse Update(OrderDTO orderDTO);
        GeneralResponse Delete(int id);
    }
}
