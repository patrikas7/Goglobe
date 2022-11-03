using System;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.DTOs.Bookings
{
    public record CreateBookingDTO([Required] DateTime Date, [Required] int TravelOfferId, [Required] string ClientId);
}
