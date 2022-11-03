using goglobe_API.Auth.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace goglobe_API.Data.Entities
{
    [Table("Bookings")]
    public class Booking : IUserOwnedResource
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BookingReference { get; set; }
        public Status Status { get; set; }
        public int TravelOfferId { get; set; }
        public TravelOffer TravelOffer { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
    }

    public enum Status {
        Confirmed = 1,
        Canceled = 2,
        Pending = 3
    }
}
