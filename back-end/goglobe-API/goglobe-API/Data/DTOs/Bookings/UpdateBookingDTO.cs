using goglobe_API.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.Bookings
{
    public record UpdateBookingDTO(Status Status, int TravelOfferId,
        string ClientId);

}
