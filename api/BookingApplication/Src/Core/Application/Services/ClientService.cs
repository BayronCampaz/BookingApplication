using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Client> Create(ClientRequest client)
        {
            var newClient = _mapper.Map<Client>(client);
            var createdClient = await _repository.Create(newClient);
            return createdClient;
        }

        public async Task<Client> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Client> Update(Guid id, ClientRequest clientRequest)
        {
            var client = _mapper.Map<Client>(clientRequest);
            Client clientToUpdate = await _repository.GetById(id);
            return await _repository.Update(client);
        }
    }
}
