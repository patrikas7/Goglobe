using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace goglobe_API.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1, 5)]
        public int StarCount { get; set; }
        public ICollection<TravelOffer> TravelOffers { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
