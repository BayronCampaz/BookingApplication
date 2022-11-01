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
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> Create(Booking booking)
        {
            await this._context.Bookings.AddAsync(booking);
            int changes = this._context.SaveChanges();

            return changes > 0 ? booking : null;

        }

        public async Task<Booking> Delete(Guid id)
        {
            Booking booking = await this.GetById(id);

            this._context.Bookings.Remove(booking);
            int changes = _context.SaveChanges();

            return changes > 0 ? booking : null;

        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetById(Guid id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<Booking> Update(Booking booking)
        {
            Booking bookingToUpdate = await GetById(booking.Id);
            bookingToUpdate.StartTime = booking.StartTime;
            bookingToUpdate.EndTime = booking.EndTime;
            _context.Bookings.Update(bookingToUpdate);
            int changes = _context.SaveChanges();
            await Task.CompletedTask;

            return changes > 0 ? booking : null;
        }
    }
}
