using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly ITableRepository _tableRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, 
                              ITableRepository tableRepository, 
                              IClientRepository clientRepository, 
                              IMapper mapper)
        {
            _repository = repository;
            _tableRepository = tableRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<Booking> Create(BookingRequest bookingRequest)
        {
            var booking = _mapper.Map<Booking>(bookingRequest);
            booking.Id = Guid.NewGuid();
            var table = await _tableRepository.GetById(bookingRequest.TableId);
            if (table is null)
            {
                throw new NotFoundException("Doesn't exist a Table with id " + bookingRequest.TableId);
            }
            var client = await _clientRepository.GetById(bookingRequest.ClientId);
            if (client is null)
            {
                throw new NotFoundException("Doesn't exist a Client with id " + bookingRequest.ClientId);
            }
            booking.Table = table;
            booking.Client = client;
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

        public async Task<Booking> Update(Guid id, BookingRequest bookingRequest)
        {
            var booking = _mapper.Map<Booking>(bookingRequest);
            Booking bookingToUpdate = await _repository.GetById(id);
            booking.Id = bookingToUpdate.Id;
            return await _repository.Update(booking);
        }
    }
}
