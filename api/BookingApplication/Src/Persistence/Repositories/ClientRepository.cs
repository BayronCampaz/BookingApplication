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

        public async Task<Client> Create(Client client)
        {
            await this._context.Clients.AddAsync(client);
            int changes = this._context.SaveChanges();

            return changes > 0 ? client : null;

        }

        public async Task<Client> Delete(Guid id)
        {
            Client client = await this.GetById(id);

            this._context.Clients.Remove(client);
            int changes = _context.SaveChanges();

            return changes > 0 ? client : null;

        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> Update(Client client)
        {
            Client clientToUpdate = await GetById(client.Id);
            clientToUpdate.Name = client.Name;
            clientToUpdate.LastName = client.LastName;
            _context.Clients.Update(clientToUpdate);
            int changes = _context.SaveChanges();
            await Task.CompletedTask;

            return changes > 0 ? client : null;
        }
    }
}
