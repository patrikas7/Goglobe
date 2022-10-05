using goglobe_API.Data.Entities;
using goglobe_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goglobe_API.Data.Repository
{
    public class BookingsRepository : IBookingRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BookingsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }   

        public async Task<Booking> Create(Booking booking)
        {
            _databaseContext.Bookings.Add(booking);
            await _databaseContext.SaveChangesAsync();

            return booking;
        }

        public async Task Delete(Booking booking)
        {
            _databaseContext.Bookings.Remove(booking);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Booking> Get(int id)
        {
            return await _databaseContext.Bookings.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _databaseContext.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByBookingReference(string bookingReference)
        {
            return await _databaseContext.Bookings.FirstOrDefaultAsync(obj => obj.BookingReference == bookingReference);
        }

        public async Task<IEnumerable<Booking>> GetTravelOfferBookings(int travelOfferId)
        {
            return await _databaseContext.Bookings.Where(x => x.TravelOfferId == travelOfferId).ToListAsync();
        }

        public async Task<Booking> Put(Booking booking)
        {
            _databaseContext.Bookings.Update(booking);
            await _databaseContext.SaveChangesAsync();

            return booking;
        }
    }
}
