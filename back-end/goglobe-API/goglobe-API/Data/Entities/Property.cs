using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace goglobe_API.Data.Entities
{
    [Table("Properties")]
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TravelProperty> TravelProperties { get; set; }
    }
}
