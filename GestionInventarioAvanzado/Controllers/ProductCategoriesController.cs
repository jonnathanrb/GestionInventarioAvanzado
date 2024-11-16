using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioAvanzado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProductCategories()
        {
            GeneralResponse response = _service.FindAll();

            int statusCode = int.Parse(response.statusCode.ToString());
            return StatusCode(statusCode, response);
        }

        [HttpGet("{id:int}", Name = "GetProductCategoryById")]
        public IActionResult GetProductCategoryById(int id)
        {
            GeneralResponse response = _service.FindById(id);

            int statusCode = int.Parse(response.statusCode.ToString());
            return StatusCode(statusCode, response);
        }

        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] CreateProductCategoryDTO dto)
        {
            GeneralResponse response = _service.Add(dto);

            int statusCode = int.Parse(response.statusCode.ToString());
            return StatusCode(statusCode, response);
        }

        [HttpPut]
        public IActionResult UpdateProductCategory([FromBody] ProductCategoryDTO dto)
        {
            GeneralResponse response = _service.Update(dto);

            int statusCode = int.Parse(response.statusCode.ToString());
            return StatusCode(statusCode, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductCategoryById")]
        public IActionResult DeleteProductCategoryById(int id)
        {
            GeneralResponse response = _service.Delete(id);

            int statusCode = int.Parse(response.statusCode.ToString());
            return StatusCode(statusCode, response);
        }
    }
}
