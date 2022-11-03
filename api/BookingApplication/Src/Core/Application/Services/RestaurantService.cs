using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;

namespace Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<RestaurantRequest> _validator;

        public RestaurantService(IRestaurantRepository repository, IMapper mapper, IValidator<RestaurantRequest> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Restaurant> Create(RestaurantRequest restaurantRequest)
        {
            _validator.ValidateAndThrow(restaurantRequest);
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
            Restaurant restaurantToUpdate = await _repository.GetById(id);
            if(restaurantToUpdate == null)
            {
                throw new NotFoundException("Doesn't exist Restaurant with id " + id);
            }
            _mapper.Map(restaurantRequest, restaurantToUpdate);
            return await _repository.Update(restaurantToUpdate);
        }
    }
}
