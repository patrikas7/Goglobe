using System;

namespace goglobe_API.Data.DTOs.Bookings
{
    public record CreateBookingDTO(DateTime Date, int TravelOfferId, int ClientId);
}
