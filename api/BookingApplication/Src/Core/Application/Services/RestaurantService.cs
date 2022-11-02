using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Restaurant> Create(RestaurantRequest restaurantRequest)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantRequest);
            restaurant.Id = Guid.NewGuid();
            var createdRestaurant = await _repository.Create(restaurant);
            return createdRestaurant;
        }

        public async Task<Restaurant> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Restaurant> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Restaurant> Update(Guid id, RestaurantRequest restaurantRequest)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantRequest);
            Restaurant restaurantToUpdate = await _repository.GetById(id);
            restaurant.Id = restaurantToUpdate.Id;
            return await _repository.Update(restaurant);
        }
    }
}
