using AutoMapper;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Models.Enums;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using GestionInventarioAvanzado.Utils;
using GestionInventarioAvanzado.Services.Interfaces;

namespace GestionInventarioAvanzado.Services
{
    public class InventoryMovementService : IInventoryMovementService
    {
        private readonly IInventoryMovementRepository _repository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;

        public InventoryMovementService(IInventoryMovementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = new Utilities();
        }

        public GeneralResponse Add(CreateInventoryMovementDTO createInventoryMovementDTO)
        {
            // Permite solamente 
            if (!Enum.IsDefined(typeof(Status), createInventoryMovementDTO.MovementType))
            {
                return _utilities.ErrorResponse([$"The status {createInventoryMovementDTO.MovementType} isn't valid"]);
            }

            InventoryMovement entityCreated = _repository.Add(_mapper.Map<InventoryMovement>(createInventoryMovementDTO) );

            if (entityCreated != null)
            {
                InventoryMovementDTO dto = _mapper.Map<InventoryMovementDTO>(entityCreated);
                return _utilities.SuccessResponse(dto);
            }

            return _utilities.ErrorResponse(new List<string> { "Inventory movement can´t be saved" });
        }

        public GeneralResponse Delete(int id)
        {
            InventoryMovement entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Inventory movement with id {id} doesn´t  exist"]);
            }

            bool wasDeleted = _repository.Delete(entity);

            if (!wasDeleted)
            {
                return _utilities.ErrorResponse([$"Inventorry movement with id {id} could not be deleted"]);
            }

            return _utilities.SuccessResponse();
        }

        public GeneralResponse FindAll()
        {
            IEnumerable<InventoryMovement> inventoryMovements = _repository.FindAll();
            List<InventoryMovementDTO> DTOs = [];

            if (!inventoryMovements.Any())
            {
                return _utilities.NotFoundResponse(["No inventory movements was found"]);
            }

            foreach (InventoryMovement inventoryMovement in inventoryMovements)
            {
                InventoryMovementDTO dto = _mapper.Map<InventoryMovementDTO>(inventoryMovement);
                DTOs.Add(dto);
            }

            return _utilities.SuccessResponse(DTOs);
        }

        public GeneralResponse FindById(int id)
        {
            InventoryMovement entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Inventory movement with id {id} doesn´t  exist"]);
            }

            InventoryMovementDTO dto = _mapper.Map<InventoryMovementDTO>(entity);

            return _utilities.SuccessResponse(dto);
        }

        public GeneralResponse Update(InventoryMovementDTO inventoryMovementDTO)
        {
            InventoryMovement entity = _repository.FindById(inventoryMovementDTO.Id);

            if (entity == null)
            {
                return this._utilities.NotFoundResponse([$"Inventory movement with id {inventoryMovementDTO.Id} was not found"]);
            }

            entity.Quantity = inventoryMovementDTO.Quantity;
            entity.Remarks = inventoryMovementDTO.Remarks;
            entity.Date = inventoryMovementDTO.Date;
            entity.ProductId = inventoryMovementDTO.ProductId;

            InventoryMovement entityUpdated = _repository.Update(entity);

            return this._utilities.SuccessResponse(_mapper.Map<InventoryMovementDTO>(entityUpdated));
        }
    }
}
