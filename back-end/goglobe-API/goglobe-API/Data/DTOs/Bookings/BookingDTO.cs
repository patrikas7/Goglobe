using goglobe_API.Data.Entities;
using System;

namespace goglobe_API.Data.DTOs.Bookings
{
    public record BookingDTO(int Id, DateTime Date, string BookingReference,
        Status Status, int TravelOfferId, int ClientId);
}
