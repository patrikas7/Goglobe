using goglobe_API.Data.Entities;
using System;

namespace goglobe_API.Data.DTOs.Bookings
{
    public record UpdateBookingDTO(DateTime Date, Status Status, int TravelOfferId,
        int ClientId);

}
