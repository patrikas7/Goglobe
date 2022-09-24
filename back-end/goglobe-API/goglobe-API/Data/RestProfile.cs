using AutoMapper;
using goglobe_API.Data.DTOs.Agencies;
using goglobe_API.Data.DTOs.TravelOffers;
using goglobe_API.Data.DTOs.Bookings;
using goglobe_API.Data.Entities;

namespace goglobe_API.Data
{
    public class RestProfile: Profile
    {
        public RestProfile()
        {
            CreateMap<Agency, AgencyDTO>();
            CreateMap<Agency, CreateAgencyDTO>();
            CreateMap<TravelOffer, TravelOfferDTO>();
            CreateMap<TravelOffer, CreateTravelOfferDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<Booking, CreateBookingDTO>();
            CreateMap<Booking, UpdateBookingDTO>();
        }
    }
}
