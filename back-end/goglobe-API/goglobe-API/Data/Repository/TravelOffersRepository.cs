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
            return await _databaseContext.TravelOffers.ToListAsync();
        }

        public async Task<IEnumerable<TravelOffer>> GetByDate(DateTime departureDate, DateTime returnDate)
        {
            return await _databaseContext.TravelOffers
                                         .Where(obj => obj.DepartureDate >= departureDate
                                                && obj.DepartureDate < returnDate
                                                && obj.ReturnDate > departureDate 
                                                && obj.ReturnDate <= returnDate)
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
