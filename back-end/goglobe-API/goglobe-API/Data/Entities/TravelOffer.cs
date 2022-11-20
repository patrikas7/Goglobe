using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goglobe_API.Data.Entities
{
    public class TravelOffer
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, Double.MaxValue)]
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

        [Range(1, 30)]
        public int PersonCount { get; set; }
        public string Description { get; set; }
        public bool IsFeedingIncluded { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<TravelPhoto> TravelPhotos { get; set; }
        public ICollection<TravelProperty> TravelProperties { get; set; }
    }
}
