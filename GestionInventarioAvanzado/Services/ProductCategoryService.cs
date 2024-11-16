using AutoMapper;
using GestionInventarioAvanzado.Mapper;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Repositories.Interfaces;
using GestionInventarioAvanzado.Services.Interfaces;
using GestionInventarioAvanzado.Utils;

namespace GestionInventarioAvanzado.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;

        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = new Utilities();
        }

        public GeneralResponse Add(CreateProductCategoryDTO createProductCategoryDTO)
        {
            ProductCategory entity = _mapper.Map<ProductCategory>(createProductCategoryDTO);

            ProductCategory entityCreated = _repository.Add(entity);

            if (entityCreated != null)
            {
                ProductCategoryDTO dto = _mapper.Map<ProductCategoryDTO>(entityCreated);
                return _utilities.SuccessResponse(dto);
            }

            return _utilities.ErrorResponse(new List<string> { "ProductCategory can´t be saved"});
        }

        public GeneralResponse Delete(int id)
        {
            ProductCategory entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Product category with id {id} doesn´t  exist"]);
            }

            bool wasDeleted = _repository.Delete(entity);

            if (!wasDeleted)
            {
                return _utilities.ErrorResponse([$"Product category with id {id} could not be deleted"]);
            }

            return _utilities.SuccessResponse();
        }

        public GeneralResponse FindAll()
        {
            IEnumerable<ProductCategory> productCategories = _repository.FindAll();
            List<ProductCategoryDTO> DTOs = new List<ProductCategoryDTO>();

            if (!productCategories.Any())
            {
                return _utilities.NotFoundResponse( ["No product categories was found"] );
            }

            foreach (ProductCategory productCategory in productCategories)
            {
                ProductCategoryDTO dto = _mapper.Map<ProductCategoryDTO>(productCategory);
                DTOs.Add(dto);
            }

            return _utilities.SuccessResponse(DTOs); 
        }

        public GeneralResponse FindById(int id)
        {
            ProductCategory entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Product category with id {id} doesn´t  exist"]);
            }

            ProductCategoryDTO dto = _mapper.Map<ProductCategoryDTO>(entity);

            return _utilities.SuccessResponse(dto);
        }

        public GeneralResponse Update(ProductCategoryDTO productCategoryDTO)
        {
            ProductCategory entity = _repository.FindById(productCategoryDTO.Id);

            if (entity == null)
            {
                return this._utilities.NotFoundResponse( [$"Product category with id {productCategoryDTO.Id} was not found"] );
            }

            entity.Name = productCategoryDTO.Name;
            entity.Description = productCategoryDTO.Description;

            ProductCategory entityUpdated = _repository.Update(entity);

            return this._utilities.SuccessResponse(_mapper.Map<ProductCategoryDTO>(entityUpdated));
        }
    }
}
