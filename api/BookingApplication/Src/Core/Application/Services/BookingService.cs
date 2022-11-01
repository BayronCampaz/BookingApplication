using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Booking> Create(Booking booking)
        {
            booking.Id = Guid.NewGuid();
            var createdBooking = await _repository.Create(booking);
            return createdBooking;
        }

        public async Task<Booking> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Booking> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Booking> Update(Guid id, Booking booking)
        {
            Booking bookingToUpdate = await _repository.GetById(id);
            booking.Id = bookingToUpdate.Id;
            return await _repository.Update(booking);
        }
    }
}
