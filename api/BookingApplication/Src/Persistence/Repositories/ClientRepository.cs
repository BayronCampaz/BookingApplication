using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateClient(Client client)
        {
            await this._context.Clients.AddAsync(client);
            int changes = this._context.SaveChanges();

            return changes > 0 ? client : null;

        }

        public async Task<Client> DeleteClient(Guid id)
        {
            Client client = await this.GetClientById(id);

            this._context.Clients.Remove(client);
            int changes = _context.SaveChanges();

            return changes > 0 ? client : null;

        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateClient(Client client)
        {
            Client clientToUpdate = await GetClientById(client.Id);
            clientToUpdate.Name = client.Name;
            _context.Clients.Update(clientToUpdate);
            int changes = _context.SaveChanges();
            await Task.CompletedTask;

            return changes > 0 ? client : null;
        }
    }
}
