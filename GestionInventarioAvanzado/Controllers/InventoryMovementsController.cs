using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioAvanzado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IInventoryMovementService _service;

        public InventoryMovementsController(IInventoryMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllInventoryMovements()
        {
            GeneralResponse response = _service.FindAll();

            return StatusCode(response.statusCode, response);
        }

        [HttpGet("{id:int}", Name = "GetInventoryMovementById")]
        public IActionResult GetInventoryMovementById(int id)
        {
            GeneralResponse response = _service.FindById(id);

            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        public IActionResult CreateInventoryMovement([FromBody] CreateInventoryMovementDTO dto)
        {
            GeneralResponse response = _service.Add(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpPut]
        public IActionResult UpdateInventoryMovement([FromBody] InventoryMovementDTO dto)
        {
            GeneralResponse response = _service.Update(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteInventoryMovementById")]
        public IActionResult DeleteInventoryMovementById(int id)
        {
            GeneralResponse response = _service.Delete(id);

            return StatusCode(response.statusCode, response);
        }
    }
}
