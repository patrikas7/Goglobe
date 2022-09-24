using goglobe_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.TravelOffers
{
    public record CreateTravelOfferDTO([Required] double Price, [Required] DateTime DepartureDate,
       [Required] DateTime ReturnDate, [Required] int PersonCount, string Description, bool IsFeedingIncluded,
       [Required] int AgencyId, [Required] int HotelId, [Required] int CountryId, [Required] int CityId);
}
