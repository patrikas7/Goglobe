using goglobe_API.Data.Entities;
using goglobe_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goglobe_API.Data.Repository
{
    public class TravelOffersRepository : ITravelOfferRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TravelOffersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<TravelOffer> Create(TravelOffer travelOffer)
        {
            _databaseContext.TravelOffers.Add(travelOffer);
            await _databaseContext.SaveChangesAsync();

            return travelOffer;
        }

        public async Task Delete(TravelOffer travelOffer)
        {
            _databaseContext.TravelOffers.Remove(travelOffer);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<TravelOffer> Get(int id)
        {
            return await _databaseContext.TravelOffers.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IEnumerable<TravelOffer>> GetAll()
        {
            return await _databaseContext.TravelOffers.Include(x => x.City).ToListAsync();
        }

        public async Task<IEnumerable<TravelOffer>> Filter(DateTime departureDate, DateTime returnDate,
                                                            int? minPrice, int? maxPrice, string destination)
        {
            return await _databaseContext.TravelOffers
                                         .Include(obj => obj.City)
                                         .Where(obj => obj.DepartureDate >= departureDate
                                                && obj.DepartureDate < returnDate
                                                && obj.ReturnDate > departureDate 
                                                && obj.ReturnDate <= returnDate
                                                && obj.Price >= minPrice
                                                && obj.Price <= maxPrice
                                                && destination != null ? obj.City.Name == destination : true)
                                         .ToListAsync();
        }

        public async Task<TravelOffer> Put(TravelOffer travelOffer)
        {
            _databaseContext.TravelOffers.Update(travelOffer);
            await _databaseContext.SaveChangesAsync();

            return travelOffer;
        }
    }
}
