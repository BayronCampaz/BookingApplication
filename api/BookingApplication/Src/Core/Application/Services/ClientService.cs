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
        public async Task<Client> CreateClient(Client client)
        {
            client.Id = Guid.NewGuid();
            var createdClient = await _repository.CreateClient(client);
            return createdClient;
        }

        public async Task<Client> DeleteClient(Guid id)
        {
            return await _repository.DeleteClient(id);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _repository.GetAllClients();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _repository.GetClientById(id);
        }

        public async Task<Client> UpdateClient(Guid id, Client client)
        {
            Client clientToUpdate = await _repository.GetClientById(id);
            client.Id = clientToUpdate.Id;
            return await _repository.UpdateClient(client);
        }
    }
}
