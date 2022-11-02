using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _repository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository repository, IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _repository = repository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<Table> Create(TableRequest tableRequest)
        {
            var table = _mapper.Map<Table>(tableRequest);
            table.Id = Guid.NewGuid();
            var restaurant = await _restaurantRepository.GetById(tableRequest.RestaurantId);
            table.Restaurant = restaurant ?? throw new NotFoundException("Doesn't exist Restaurant with id " + tableRequest.RestaurantId);
            var createdTable = await _repository.Create(table);
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

        public async Task<Table> Update(Guid id, TableRequest tableRequest)
        {
            var table = _mapper.Map<Table>(tableRequest);
            Table tableToUpdate = await _repository.GetById(id);
            table.Id = tableToUpdate.Id;
            return await _repository.Update(table);
        }
    }
}
