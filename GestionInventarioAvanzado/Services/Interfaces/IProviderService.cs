using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Services.Interfaces
{
    public interface IProviderService
    {
        GeneralResponse FindAll();
        GeneralResponse FindById(int id);
        GeneralResponse Add(CreateProviderDTO createProviderDTO);
        GeneralResponse Update(ProviderDTO providerDTO);
        GeneralResponse Delete(int id);
    }
}
