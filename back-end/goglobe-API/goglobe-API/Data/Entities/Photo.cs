using System.Collections.Generic;

namespace goglobe_API.Data.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public ICollection<TravelPhoto> TravelPhoto { get; set; }
    }
}
