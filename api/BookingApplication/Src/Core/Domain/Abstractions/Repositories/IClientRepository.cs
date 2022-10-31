using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetAllClients();
        public Task<Client> GetClientById(Guid id);
        public Task<Client> CreateClient(Client client);
        public Task<Client> UpdateClient(Client client);
        public Task<Client> DeleteClient(Guid id);

    }
}
