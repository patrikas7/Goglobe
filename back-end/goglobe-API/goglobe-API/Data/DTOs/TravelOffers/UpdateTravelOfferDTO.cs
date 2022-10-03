using System;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.TravelOffers
{
    public record UpdateTravelOfferDTO(double Price, DateTime DepartureDate,
          DateTime ReturnDate, int PersonCount, string Description, bool IsFeedingIncluded,
          int AgencyId, int HotelId, int CountryId, int CityId);
}
