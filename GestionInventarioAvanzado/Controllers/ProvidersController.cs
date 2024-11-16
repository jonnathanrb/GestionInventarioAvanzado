using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioAvanzado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _service;

        public ProvidersController(IProviderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProviders()
        {
            GeneralResponse response = _service.FindAll();

            return StatusCode(response.statusCode, response);
        }

        [HttpGet("{id:int}", Name = "GetProviderById")]
        public IActionResult GetProductCategoryById(int id)
        {
            GeneralResponse response = _service.FindById(id);

            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        public IActionResult CreateProviders([FromBody] CreateProviderDTO dto)
        {
            GeneralResponse response = _service.Add(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpPut]
        public IActionResult UpdateProviders([FromBody] ProviderDTO dto)
        {
            GeneralResponse response = _service.Update(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteProviderById")]
        public IActionResult DeleteProviderById(int id)
        {
            GeneralResponse response = _service.Delete(id);

            return StatusCode(response.statusCode, response);
        }
    }
}
