using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Booking> Create(BookingRequest booking)
        {
            var newBooking = _mapper.Map<Booking>(booking);
            var createdBooking = await _repository.Create(newBooking);
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

        public async Task<Booking> Update(Guid id, BookingRequest bookingRequest)
        {
            var booking = _mapper.Map<Booking>(bookingRequest);
            Booking bookingToUpdate = await _repository.GetById(id);
            booking.Id = bookingToUpdate.Id;
            return await _repository.Update(booking);
        }
    }
}
