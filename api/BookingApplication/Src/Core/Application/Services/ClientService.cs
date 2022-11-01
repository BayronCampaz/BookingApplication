using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }
        public async Task<Client> Create(Client client)
        {
            client.Id = Guid.NewGuid();
            var createdClient = await _repository.Create(client);
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

        public async Task<Client> Update(Guid id, Client client)
        {
            Client clientToUpdate = await _repository.GetById(id);
            client.Id = clientToUpdate.Id;
            return await _repository.Update(client);
        }
    }
}
