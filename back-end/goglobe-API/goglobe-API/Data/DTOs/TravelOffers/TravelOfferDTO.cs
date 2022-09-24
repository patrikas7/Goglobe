using goglobe_API.Data.Entities;
using System;
using System.Collections.Generic;

namespace goglobe_API.Data.DTOs.TravelOffers
{
    public record TravelOfferDTO(int Id, double Price, DateTime DepartureDate,
        DateTime ReturnDate, int PersonCount, string Description, bool IsFeedingIncluded,
        Agency Agency, Hotel Hotel, Country Country, City City, List<Booking> Bookings,
        List<TravelPhoto> TravelPhotos, List<TravelProperty> TravelProperties);
}
