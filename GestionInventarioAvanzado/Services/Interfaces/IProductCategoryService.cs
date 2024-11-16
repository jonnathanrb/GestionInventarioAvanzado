using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;

namespace GestionInventarioAvanzado.Services.Interfaces
{
    public interface IProductCategoryService
    {
        GeneralResponse FindAll();
        GeneralResponse FindById(int id);
        GeneralResponse Add(CreateProductCategoryDTO createProductCategoryDTO);
        GeneralResponse Update(ProductCategoryDTO productCategoryDTO);
        GeneralResponse Delete(int id);
    }
}
