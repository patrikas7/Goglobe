using goglobe_API.Data.Entities;
using System;
using System.Collections.Generic;

namespace goglobe_API.Data.DTOs.TravelOffers
{
    public record TravelOfferDTO(int Id, double Price, DateTime DepartureDate,
        DateTime ReturnDate, int PersonCount, string Description, bool IsFeedingIncluded,
        int AgencyId, int HotelId, int CountryId, int CityId, List<Booking> Bookings,
        List<TravelPhoto> TravelPhotos, List<TravelProperty> TravelProperties);
}
