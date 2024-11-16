using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioAvanzado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            GeneralResponse response = _service.FindAll();

            return StatusCode(response.statusCode, response);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            GeneralResponse response = _service.FindById(id);

            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        public IActionResult CreateProducts([FromBody] CreateProductDTO dto)
        {
            GeneralResponse response = _service.Add(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpPut]
        public IActionResult UpdateProducts([FromBody] ProductDTO dto)
        {
            GeneralResponse response = _service.Update(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteProductById")]
        public IActionResult DeleteProductById(int id)
        {
            GeneralResponse response = _service.Delete(id);

            return StatusCode(response.statusCode, response);
        }
    }
}
