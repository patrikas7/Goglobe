using System;

namespace goglobe_API.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BookingReference { get; set; }
        public Status Status { get; set; }
        public int TravelOfferId { get; set; }
        public TravelOffer TravelOffer { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }

    public enum Status {
        Confirmed,
        Canceled,
        Pending
    }
}
