using AutoMapper;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using GestionInventarioAvanzado.Utils;
using GestionInventarioAvanzado.Services.Interfaces;

namespace GestionInventarioAvanzado.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = new Utilities();
        }

        public GeneralResponse Add(CreateProductDTO createProductDTO)
        {
            Product entity = _mapper.Map<Product>(createProductDTO);
            entity.CreatedAt = DateTime.Now;

            Product entityCreated = _repository.Add(entity);

            if (entityCreated != null)
            {
                ProductDTO dto = _mapper.Map<ProductDTO>(entityCreated);
                return _utilities.SuccessResponse(dto);
            }

            return _utilities.ErrorResponse(new List<string> { "Product can´t be saved" });
        }

        public GeneralResponse Delete(int id)
        {
            Product entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Product with id {id} doesn´t  exist"]);
            }

            bool wasDeleted = _repository.Delete(entity);

            if (!wasDeleted)
            {
                return _utilities.ErrorResponse([$"Product with id {id} could not be deleted"]);
            }

            return _utilities.SuccessResponse();
        }

        public GeneralResponse FindAll()
        {
            IEnumerable<Product> products = _repository.FindAll();
            List<ProductDTO> DTOs = new List<ProductDTO>();

            if (!products.Any())
            {
                return _utilities.NotFoundResponse(["No products was found"]);
            }

            foreach (Product product in products)
            {
                ProductDTO dto = _mapper.Map<ProductDTO>(product);
                DTOs.Add(dto);
            }

            return _utilities.SuccessResponse(DTOs);
        }

        public GeneralResponse FindById(int id)
        {
            Product entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Product with id {id} doesn´t  exist"]);
            }

            ProductDTO dto = _mapper.Map<ProductDTO>(entity);

            return _utilities.SuccessResponse(dto);
        }

        public GeneralResponse Update(ProductDTO productDTO)
        {
            Product entity = _repository.FindById(productDTO.Id);

            if (entity == null)
            {
                return this._utilities.NotFoundResponse([$"Product with id {productDTO.Id} was not found"]);
            }

            entity.Name = productDTO.Name;
            entity.Price = productDTO.Price;
            entity.Description = productDTO.Description;
            entity.Cost = productDTO.Cost;
            entity.SKU = productDTO.SKU;
            entity.StockQuantity = productDTO.StockQuantity;
            entity.ReorderQuantity = productDTO.ReorderQuantity;
            entity.ProductCategoryId = productDTO.ProductCategoryId;
            entity.ProviderId = productDTO.ProviderId;

            Product entityUpdated = _repository.Update(entity);

            return this._utilities.SuccessResponse(_mapper.Map<ProductDTO>(entityUpdated));
        }
    }
}
