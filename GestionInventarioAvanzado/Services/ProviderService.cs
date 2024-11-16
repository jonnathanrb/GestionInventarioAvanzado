using AutoMapper;
using GestionInventarioAvanzado.Models.ApiResponses;
using GestionInventarioAvanzado.Models.DTO;
using GestionInventarioAvanzado.Models;
using GestionInventarioAvanzado.Repositories.Interfaces;
using GestionInventarioAvanzado.Services.Interfaces;
using GestionInventarioAvanzado.Utils;

namespace GestionInventarioAvanzado.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;
        private readonly Utilities _utilities;

        public ProviderService(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _utilities = new Utilities();
        }

        public GeneralResponse Add(CreateProviderDTO createProviderDTO)
        {
            Provider entity = _mapper.Map<Provider>(createProviderDTO);
            entity.CreatedAt = DateTime.Now;

            Provider entityCreated = _repository.Add(entity);

            if (entityCreated != null)
            {
                ProviderDTO dto = _mapper.Map<ProviderDTO>(entityCreated);
                return _utilities.SuccessResponse(dto);
            }

            return _utilities.ErrorResponse(new List<string> { "Provider can´t be saved" });
        }

        public GeneralResponse Delete(int id)
        {
            Provider entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Provider with id {id} doesn´t  exist"]);
            }

            bool wasDeleted = _repository.Delete(entity);

            if (!wasDeleted)
            {
                return _utilities.ErrorResponse([$"Provider with id {id} could not be deleted"]);
            }

            return _utilities.SuccessResponse();
        }

        public GeneralResponse FindAll()
        {
            IEnumerable<Provider> providers = _repository.FindAll();
            List<ProviderDTO> DTOs = new List<ProviderDTO>();

            if (!providers.Any())
            {
                return _utilities.NotFoundResponse(["No providers was found"]);
            }

            foreach (Provider provider in providers)
            {
                ProviderDTO dto = _mapper.Map<ProviderDTO>(provider);
                DTOs.Add(dto);
            }

            return _utilities.SuccessResponse(DTOs);
        }

        public GeneralResponse FindById(int id)
        {
            Provider entity = _repository.FindById(id);

            if (entity == null)
            {
                return _utilities.NotFoundResponse([$"Provider with id {id} doesn´t  exist"]);
            }

            ProviderDTO dto = _mapper.Map<ProviderDTO>(entity);

            return _utilities.SuccessResponse(dto);
        }

        public GeneralResponse Update(ProviderDTO providerDTO)
        {
            Provider entity = _repository.FindById(providerDTO.Id);

            if (entity == null)
            {
                return this._utilities.NotFoundResponse([$"Provider with id {providerDTO.Id} was not found"]);
            }

            entity.Name = providerDTO.Name;
            entity.Adress = providerDTO.Adress;
            entity.PhoneNumber = providerDTO.PhoneNumber;
            entity.Email = providerDTO.Email;

            Provider entityUpdated = _repository.Update(entity);

            return this._utilities.SuccessResponse(_mapper.Map<ProviderDTO>(entityUpdated));
        }
    }
}
