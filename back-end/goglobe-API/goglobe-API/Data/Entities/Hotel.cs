using System.Collections.Generic;

namespace goglobe_API.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarCount { get; set; }
        public ICollection<TravelOffer> TravelOffers { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
