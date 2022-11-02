using Domain.Abstractions.RequestModels;
using Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _service;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _service = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingRequest booking)
        {
            return Ok(await this._service.Create(booking));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(Guid id, BookingRequest booking)
        {
            return this.Ok(await this._service.Update(id, booking));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            return this.Ok(await this._service.Delete(id));
        }


    }
}
