﻿using goglobe_API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goglobe_API.Interfaces
{
    public interface ITravelOfferRepository
    {
        Task<IEnumerable<TravelOffer>> GetAll();
        Task<TravelOffer> Get(int id);

        Task<TravelOffer> Create(TravelOffer travelOffer);

        Task<TravelOffer> Put(TravelOffer travelOffer);

        Task Delete(TravelOffer travelOffer);
    }
}