using goglobe_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goglobe_API.Interfaces
{
    public interface ITravelOfferRepository
    {
        Task<IEnumerable<TravelOffer>> GetAll();
        Task<TravelOffer> Get(int id);
        Task<IEnumerable<TravelOffer>> Filter(DateTime departureDate, DateTime returnDate,
                                                            int? minPrice, int? maxPrice, string destination);

        Task<TravelOffer> Create(TravelOffer travelOffer);

        Task<TravelOffer> Put(TravelOffer travelOffer);

        Task Delete(TravelOffer travelOffer);
    }
}
