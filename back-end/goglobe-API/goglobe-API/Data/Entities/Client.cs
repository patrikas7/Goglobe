using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace goglobe_API.Data.Entities
{
    [Table("Clients")]
    public class Client: User
    {
        public DateTime BirthDate { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
