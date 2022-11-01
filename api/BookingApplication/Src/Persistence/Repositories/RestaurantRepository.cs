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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            await this._context.Restaurants.AddAsync(restaurant);
            int changes = this._context.SaveChanges();

            return changes > 0 ? restaurant : null;

        }

        public async Task<Restaurant> Delete(Guid id)
        {
            Restaurant restaurant = await this.GetById(id);

            this._context.Restaurants.Remove(restaurant);
            int changes = _context.SaveChanges();

            return changes > 0 ? restaurant : null;

        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetById(Guid id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);;
        }

        public async Task<Restaurant> Update(Restaurant restaurant)
        {
            Restaurant restaurantToUpdate = await GetById(restaurant.Id);
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.Address = restaurant.Address;
            restaurantToUpdate.City = restaurant.City;
            _context.Restaurants.Update(restaurantToUpdate);
            int changes = _context.SaveChanges();
            await Task.CompletedTask;

            return changes > 0 ? restaurant : null;
        }
    }
}
