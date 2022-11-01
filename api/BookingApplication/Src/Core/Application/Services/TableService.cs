using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _repository;
        private readonly IRestaurantRepository _restaurantRepository;

        public TableService(ITableRepository repository, IRestaurantRepository restaurantRepository)
        {
            _repository = repository;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<Table> Create(Table table)
        {
            table.Id = Guid.NewGuid();
            var createdTable = await _repository.Create(table);
            var restaurant = await _restaurantRepository.GetById(createdTable.Restaurant.Id);
            table.Restaurant = restaurant ?? throw new Exception("Doesn't exist Restaurant with id " + table.Restaurant.Id);
            return createdTable;
        }

        public async Task<Table> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Table>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Table> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Table> Update(Guid id, Table table)
        {
            Table tableToUpdate = await _repository.GetById(id);
            table.Id = tableToUpdate.Id;
            return await _repository.Update(table);
        }
    }
}
