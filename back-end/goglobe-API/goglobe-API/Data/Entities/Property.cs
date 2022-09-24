using System.Collections.Generic;

namespace goglobe_API.Data.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TravelProperty> TravelProperties { get; set; }
    }
}
