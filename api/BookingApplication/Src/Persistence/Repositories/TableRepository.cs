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
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Table> Create(Table table)
        {
            await this._context.Tables.AddAsync(table);
            int changes = this._context.SaveChanges();

            return changes > 0 ? table : null;

        }

        public async Task<Table> Delete(Guid id)
        {
            Table table = await this.GetById(id);

            this._context.Tables.Remove(table);
            int changes = _context.SaveChanges();

            return changes > 0 ? table : null;

        }

        public async Task<IEnumerable<Table>> GetAll()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetById(Guid id)
        {
            return await _context.Tables.FindAsync(id);
        }

        public async Task<Table> Update(Table table)
        {
            Table tableToUpdate = await GetById(table.Id);
            tableToUpdate.Number = table.Number;
            tableToUpdate.Description = table.Description;
            _context.Tables.Update(tableToUpdate);
            int changes = _context.SaveChanges();
            await Task.CompletedTask;

            return changes > 0 ? table : null;
        }
    }
}
