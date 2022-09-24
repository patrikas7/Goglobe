using System;
using System.Collections.Generic;

namespace goglobe_API.Data.Entities
{
    public class Client: User
    {
        public DateTime BirthDate { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
