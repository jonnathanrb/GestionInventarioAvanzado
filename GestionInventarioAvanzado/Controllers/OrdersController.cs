using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioAvanzado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            GeneralResponse response = _service.FindAll();

            return StatusCode(response.statusCode, response);
        }

        [HttpGet("{id:int}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            GeneralResponse response = _service.FindById(id);

            return StatusCode(response.statusCode, response);
        }

        [HttpPost]
        public IActionResult CreateOrders([FromBody] CreateOrderDTO dto)
        {
            GeneralResponse response = _service.Add(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpPut]
        public IActionResult UpdateOrders([FromBody] OrderDTO dto)
        {
            GeneralResponse response = _service.Update(dto);

            return StatusCode(response.statusCode, response);
        }

        [HttpDelete("{id:int}", Name = "DeleteOrderById")]
        public IActionResult DeleteOrderById(int id)
        {
            GeneralResponse response = _service.Delete(id);

            return StatusCode(response.statusCode, response);
        }
    }
}
