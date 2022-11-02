using Domain.Abstractions.RequestModels;
using Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IRestaurantService _service;

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _service = restaurantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(RestaurantRequest restaurant)
        {
            return Ok(await this._service.Create(restaurant));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(Guid id, RestaurantRequest restaurant)
        {
            return this.Ok(await this._service.Update(id, restaurant));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(Guid id)
        {
            return this.Ok(await this._service.Delete(id));
        }


    }
}
