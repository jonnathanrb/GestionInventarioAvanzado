using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Services.Interfaces
{
    public interface IProductService
    {
        GeneralResponse FindAll();
        GeneralResponse FindById(int id);
        GeneralResponse Add(CreateProductDTO createProductDTO);
        GeneralResponse Update(ProductDTO productDTO);
        GeneralResponse Delete(int id);
    }
}
