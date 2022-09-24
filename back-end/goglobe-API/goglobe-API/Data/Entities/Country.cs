using System.Collections.Generic;

namespace goglobe_API.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TravelOffer> TravelOffers { get; set; }
    }
}
