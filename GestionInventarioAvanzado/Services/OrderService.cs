using AutoMapper;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using GestionInventarioAvanzado.Services.Interfaces;
using GestionInventarioAvanzado.Utils;
using GestionInventarioAvanzado.Models.Enums;

namespace GestionInventarioAvanzado.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = new Utilities();
        }

        public GeneralResponse Add(CreateOrderDTO createOrderDTO)
        {
            // Permite solamente 
            if (!Enum.IsDefined(typeof(Status), createOrderDTO.Status))
            {
                return _utilities.ErrorResponse([$"The status {createOrderDTO.Status} isn't valid"]);
            }

            List<OrderItem> orderItems = [];

            foreach (CreateOrderItemDTO orderItemDTO in createOrderDTO.OrderItems)
            {
                orderItems.Add( _mapper.Map<OrderItem>(orderItemDTO) );
            }

            Order entity = _mapper.Map<Order>(createOrderDTO);

            Order entityCreated = _repository.Add(entity);

            if (entityCreated != null)
            {
                OrderDTO dto = _mapper.Map<OrderDTO>(entityCreated);
                return _utilities.SuccessResponse(dto);
            }

            return _utilities.ErrorResponse(new List<string> { "Order can´t be saved" });
        }

        public GeneralResponse Delete(int id)
        {
            Order entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Order with id {id} doesn´t  exist"]);
            }

            bool wasDeleted = _repository.Delete(entity);

            if (!wasDeleted)
            {
                return _utilities.ErrorResponse([$"Order with id {id} could not be deleted"]);
            }

            return _utilities.SuccessResponse();
        }

        public GeneralResponse FindAll()
        {
            IEnumerable<Order> orders = _repository.FindAll();
            List<OrderDTO> DTOs = new List<OrderDTO>();

            if (!orders.Any())
            {
                return _utilities.NotFoundResponse(["No orders was found"]);
            }

            foreach (Order order in orders)
            {
                OrderDTO dto = _mapper.Map<OrderDTO>(order);
                DTOs.Add(dto);
            }

            return _utilities.SuccessResponse(DTOs);
        }

        public GeneralResponse FindById(int id)
        {
            Order entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Order with id {id} doesn´t  exist"]);
            }

            OrderDTO dto = _mapper.Map<OrderDTO>(entity);

            return _utilities.SuccessResponse(dto);
        }

        public GeneralResponse Update(OrderDTO orderDTO)
        {
            Order entity = _repository.FindById(orderDTO.Id);

            if (entity == null)
            {
                return this._utilities.NotFoundResponse([$"Order with id {orderDTO.Id} was not found"]);
            }

            entity.OrderDate = orderDTO.OrderDate;
            entity.ProviderId = orderDTO.ProviderId;
            entity.TotalAmount = orderDTO.TotalAmount;
            entity.Status = orderDTO.Status;

            Order entityUpdated = _repository.Update(entity);

            return this._utilities.SuccessResponse(_mapper.Map<OrderDTO>(entityUpdated));
        }
    }
}
